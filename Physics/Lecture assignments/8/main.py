import numpy as np
import matplotlib.pyplot as plt
from scipy.integrate import solve_ivp

# Входные параметры
m = float(input("Введите массу груза (кг): "))
k = float(input("Введите коэффициент жесткости пружины (Н/м): "))
b = float(input("Введите коэффициент сопротивления среды: "))

# Уравнения движения
def spring_mass_damped(t, y):
    x, v = y
    dxdt = v
    dvdt = -(k / m) * x - (b / m) * v
    return [dxdt, dvdt]

gamma = b / (2 * m)
t_damping = -np.log(0.01) / gamma  # время, за которое амплитуда уменьшится до 1%
t_damping += 1

# Решение ОДУ
t_span = (0, t_damping)  # временной интервал
t_eval = np.linspace(0, t_damping, 500)
y0 = [10, 0]     # начальные условия
sol = solve_ivp(spring_mass_damped, t_span, y0, t_eval=t_eval)

# Вычисление энергий
x = sol.y[0]
v = sol.y[1]
Ek = 0.5 * m * v**2       # Кинетическая энергия
Ep = 0.5 * k * x**2       # Потенциальная энергия
E_total = Ek + Ep         # Полная механическая энергия

# Визуализация
plt.plot(sol.t, Ek, label="Кинетическая энергия", color='blue')
plt.plot(sol.t, Ep, label="Потенциальная энергия", color='red')
plt.plot(sol.t, E_total, label="Полная механическая энергия", color='black')
plt.xlabel("Время (с)")
plt.ylabel("Энергия (Дж)")
plt.legend()
plt.title("Энергетические превращения при колебании груза на пружине")
plt.show()
