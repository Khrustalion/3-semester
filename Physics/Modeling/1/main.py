import numpy as np
import matplotlib.pyplot as plt
from scipy.optimize import fsolve
from scipy.integrate import quad

g_L = 1.62  # м/с^2, ускорение свободного падения на Луне
M = 2150  # кг, масса корабля
Vp = 3660  # м/с, скорость истечения продуктов сгорания
m_fuel = 150  # кг, масса топлива
fuel_rate = 15  # кг/с, расход топлива
V0 = 17  # Начальная вертикальная скорость
H0 = 2400  # начальная высота, например
V_safe = 3  # предельная скорость для посадки, м/с

def meschersky(t):
    return -Vp * np.log((M + m_fuel) / (M + m_fuel - fuel_rate * t)) + g_L * t


def mechersky_a(t):
    fuel_mass = m_fuel - fuel_rate * t
    mass = M + fuel_mass
    return -fuel_rate * Vp / mass + g_L


# Уравнение для нахождения времени работы двигателя t_fall - время свободного падения, t_engine_on - время падения с включенным двигателем
def equations(vars):
    t_fall, t_engine_on = vars
    V_0_egine_on = V0 + g_L * t_fall
    h_engine_on, e = quad(meschersky, 0, t_engine_on)
    eq1 = V_0_egine_on - Vp * np.log((M + m_fuel) / (M + m_fuel - fuel_rate * t_engine_on)) + g_L * t_engine_on - V_safe
    eq2 = V0 * t_fall + 0.5 * g_L * t_fall**2 + V_0_egine_on * t_engine_on + h_engine_on - H0

    return [eq1, eq2]

t_fall, t_engine_on = fsolve(equations, (0, 0))

H_engine_on = H0 - (V0 * t_fall + 0.5 * g_L * t_fall**2) # Высота включения двигателей

print(f"высота включения двигателей: {H_engine_on:.2f}")

V_0_egine_on = V0 + g_L * t_fall # скорость при включении двигателей

print(f"скорость при включении двигателей: {V_0_egine_on:.2f}")

# Вывод скорости на высоте 0 (после торможения)
final_velocity = V_0_egine_on - Vp * np.log((M + m_fuel) / (M + m_fuel - fuel_rate * t_engine_on)) + g_L * t_engine_on
print(f"Вертикальная скорость при высоте 0: {final_velocity:.2f} м/с")

# Подготовка для графиков
time_values = np.linspace(0, t_fall + t_engine_on, 500)
V_y_values = []
a_y_values = []
H_values = []

for t in time_values:
    a = mechersky_a(t - t_fall) if t >= t_fall else 0
    a_y = g_L if t <= t_fall else a

    v, e = quad(mechersky_a, 0, t - t_fall) if t >= t_fall else (0, 0)
    V_y = V0 + a_y * t if t <= t_fall else V_0_egine_on + v
    h_engine_on = 0
    if t >= t_fall: h_engine_on, e = quad(meschersky, 0, t - t_fall)
    H = (H0 - (V0 * t + 0.5 * a_y * t**2)) if t <= t_fall else (H_engine_on - V_0_egine_on * (t - t_fall) - h_engine_on)
    V_y_values.append(V_y)
    a_y_values.append(a_y)
    H_values.append(H)

# Графики
plt.figure()

plt.subplot(3, 1, 1)
plt.plot(time_values, V_y_values, label="Скорость $V_y$")
plt.ylabel("Скорость (м/с)")
plt.title("Зависимость скорости от времени")
plt.legend()

plt.subplot(3, 1, 2)
plt.plot(time_values, a_y_values, label="Ускорение $a_y$", color="orange")
plt.ylabel("Ускорение (м/с²)")
plt.title("Зависимость ускорения от времени")
plt.legend()

plt.subplot(3, 1, 3)
plt.plot(time_values, H_values, label="Высота $H$", color="green")
plt.xlabel("Время (с)")
plt.ylabel("Высота (м)")
plt.title("Зависимость высоты от времени")
plt.legend()

plt.tight_layout()
plt.show()
