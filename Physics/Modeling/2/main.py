from matplotlib.animation import FuncAnimation
import numpy as np
from scipy.integrate import solve_ivp
from scipy.optimize import fsolve
import matplotlib.pyplot as plt

# Константы
e = 1.6e-19  # заряд электрона, Кл
m = 9.1e-31  # масса электрона, кг
r = 0.11      # внутренний радиус, м
R = 0.23      # внешний радиус, м
L = 0.31      # длина конденсатора, м
Vx = 7.5e5    # начальная скорость вдоль x, м/с

dR = (R - r) / 2

accuracy = 700

# Время интегрирования
t_max = L / Vx  # время пролёта через конденсатор
t_span = (0, t_max)
t_eval = np.linspace(0, t_max, accuracy)

def equations(var):
    U = var[0]
    # Вспомогательная функция: производные
    def system(t, y):
        y_1, y_2 = y
        E = U / ((r + dR + y_1) * np.log(R / r))
        dydt = [y_2, e * E / m]
        return dydt

    y_0 = [0, 0]

    solution = solve_ivp(system, t_span, y_0, t_eval=t_eval)

    # Извлекаем результаты
    y = solution.y[0]  # y(t)
    vy = solution.y[1] # y'(t)

    # Уравнение для поиска минимального значения U
    eq = y[-1] - dR

    return [eq]

U_min = fsolve(equations, 0)[0]

def system(t, y):
    y_1, y_2 = y
    E = U_min / ((r + dR + y_1) * np.log(R / r))
    dydt = [y_2, e * E / m]
    return dydt

y_0 = [0, 0]

solution = solve_ivp(system, t_span, y_0, t_eval=t_eval)

t = solution.t
y = np.array(solution.y[0]) + (r + dR)
vy = solution.y[1]

ay = [e * U_min / (m * (y_pos) * np.log(R / r)) for y_pos in y]


# Создание графика
fig, ax = plt.subplots(figsize=(8, 6))
ax.set_xlim(-0.1, 2 * L)
ax.set_ylim(-2 * R, 2 * R)
ax.set_title("Моделирование движения электрона в конденсаторе")
ax.set_xlabel("x (м)")
ax.set_ylabel("y (м)")
ax.grid()

# Объекты для анимации
electron = ax.scatter([], [], color='blue', s=5, label='Электрон')  # Увеличен размер точки
trajectory, = ax.plot([], [], '-', color='orange', lw=1, label='Траектория')
cond = [ax.plot([0, L], [x, x], color='black')[0] for x in (R, -R, r, -r)]  # Черные горизонтальные линии

ax.legend()

# Списки для координат
x_vals = np.linspace(0, L, accuracy)
y_vals = y

# Функция инициализации
def init():
    electron.set_offsets([[0, 0]])  # Пустой набор точек для scatter (двумерный массив)
    trajectory.set_data([], [])
    return electron, trajectory, *cond

# Функция обновления
def update(frame):
    electron.set_offsets([[x_vals[frame], y_vals[frame]]])  # Обновление положения электрона
    trajectory.set_data(x_vals[frame], y_vals[frame])  # Обновление траектории
    return electron, trajectory, *cond

# Фреймы для анимации
frames = range(accuracy)

# Создание анимации
ani = FuncAnimation(fig, update, frames=frames, init_func=init, blit=True, interval=0)

# Показать анимацию
plt.show()

# Траектория x(t)
x = Vx * t

# Построение графиков
plt.figure(figsize=(12, 8))

# y(x)
plt.subplot(2, 2, 1)
plt.plot(x, y, label='y(x)')
plt.xlabel('x, м')
plt.ylabel('y, м')
plt.title('Траектория движения y(x)')
plt.grid()
plt.legend()

# Vy(t)
plt.subplot(2, 2, 2)
plt.plot(t, vy, label='Vy(t)', color='orange')
plt.xlabel('t, с')
plt.ylabel('Vy, м/с')
plt.title('Скорость Vy(t)')
plt.grid()
plt.legend()

# ay(t)
plt.subplot(2, 2, 3)
plt.plot(t, ay, label='ay(t)', color='green')
plt.xlabel('t, с')
plt.ylabel('ay, м/с^2')
plt.title('Ускорение ay(t)')
plt.grid()
plt.legend()

# y(t)
plt.subplot(2, 2, 4)
plt.plot(t, y, label='y(t)', color='red')
plt.xlabel('t, с')
plt.ylabel('y, м')
plt.title('Координата y(t)')
plt.grid()
plt.legend()

plt.tight_layout()
plt.show()

print(f"Минимальное напряжение: {round(U_min, 3)} В")
