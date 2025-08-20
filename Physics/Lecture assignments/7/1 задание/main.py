import numpy as np
import matplotlib.pyplot as plt
from scipy.integrate import solve_ivp

# Константы
g = 9.81  # ускорение свободного падения, м/с^2

# Входные параметры
v0 = float(input("Введите начальную скорость в м/с: "))  # начальная скорость, м/с
alpha = float(input("Введите начальный угол в градусах: "))  # угол броска, градусы
y0 = float(input("Введите начальную высоту в м: "))  # начальная высота, м
k =  float(input("Введите коэффициент сопротивления: ")) # коэффициент сопротивления, кг/с
m = float(input("Введите массу тела в кг: "))  # масса тела, кг

# Начальные условия
v0_x = v0 * np.cos(np.radians(alpha))  # начальная скорость по x
v0_y = v0 * np.sin(np.radians(alpha))  # начальная скорость по y
initial_conditions = [0, y0, v0_x, v0_y]  # [x0, y0, vx0, vy0]

# Функция для системы ОДУ
def equations(t, variables):
    x, y, vx, vy = variables
    ax = -k / m * vx
    ay = -g - (k / m) * vy
    return [vx, vy, ax, ay]

t_max = ((v0_y + (v0_y**2 + 2 * g * y0)**.5) / g) # время полета тела без учета трения о воздух
# Решение системы ОДУ
time_span = (0, t_max)  # временной интервал для расчета
time_eval = np.linspace(0, t_max, 500)  # временные точки для оценки

solution = solve_ivp(equations, time_span, initial_conditions, t_eval=time_eval, method='RK45')

# Данные для графиков
y = solution.y[1]

left_side = -1
for i in range(len(y)): # находим последнее значение перед падением тела
    if y[i] < 0:
        break
    left_side = i

y = y[:left_side]
x = solution.y[0][:left_side]
vx = solution.y[2][:left_side]
vy = solution.y[3][:left_side]
time = solution.t[:left_side]

# Построение графиков
plt.figure(figsize=(15, 5))

# График 1: Траектория движения
plt.subplot(1, 3, 1)
plt.plot(x, y)
plt.xlabel("x, м")
plt.ylabel("y, м")
plt.title("Траектория движения")
plt.grid()

# График 2: Скорость от времени
plt.subplot(1, 3, 2)
plt.plot(time, vx, label="v_x(t)")
plt.plot(time, vy, label="v_y(t)")
plt.xlabel("Время, с")
plt.ylabel("Скорость, м/с")
plt.legend()
plt.title("Скорость от времени")
plt.grid()

# График 3: Координаты x и y от времени
plt.subplot(1, 3, 3)
plt.plot(time, x, label="x(t)")
plt.plot(time, y, label="y(t)")
plt.xlabel("Время, с")
plt.ylabel("Координаты, м")
plt.legend()
plt.title("Координаты от времени")
plt.grid()

plt.tight_layout()
plt.show()
