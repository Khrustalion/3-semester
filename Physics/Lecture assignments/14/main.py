import numpy as np
import matplotlib.pyplot as plt

# Считывание данных с клавиатуры
eps1 = float(input("Введите диэлектрическую проницаемость первой среды (ε1): "))
eps2 = float(input("Введите диэлектрическую проницаемость второй среды (ε2): "))
magnitude_E = float(input("Введите модуль напряженности внешнего поля (E): "))
angle_E_deg = float(input("Введите угол направления напряженности поля (в градусах): "))


# Перевод угла из градусов в радианы
angle_E = np.radians(angle_E_deg)

# Проверим, чтобы значение не выходило за пределы допустимого диапазона для arcsin
sin_angle_refraction = np.sin(angle_E) * np.sqrt(eps1 / eps2)


# Создаем координатную сетку
x = np.array(np.linspace(-1, 1, 1000))
y = np.array(np.linspace(-1, 1, 1000))
X, Y = np.meshgrid(x, y)

# Напряженность поля в первой среде (падающая волна)
Ex1 = magnitude_E * np.cos(angle_E)
Ey1 = magnitude_E * np.sin(angle_E)

Dx1 = Ex1
Dy1 = Ey1

# Напряженность поля во второй среде (преломленная волна)
Ex2 = Ex1 * eps1 / eps2
Ey2 = Ey1

# cмещение в обеих средах
Dx2 = Dx1  # Индукция в первой среде
Dy2 = Dy1 * eps2 / eps1  # Индукция во второй среде

# Создаем график
fig, ax = plt.subplots(figsize=(8, 8))

x_1 = x[x <= 0]
x_2 = x[x >= 0]

X_1, Y_1 = np.meshgrid(x_1, y)
X_2, Y_2 = np.meshgrid(x_2, y)

ax.streamplot(X_1, Y_1, Ex1 * np.ones_like(X_1), Ey1 * np.ones_like(Y_1))
ax.streamplot(X_2, Y_2, Ex2 * np.ones_like(X_2), Ey2 * np.ones_like(Y_2))

ax.scatter([], [], color='blue', label=f'Среда 1: $\\varepsilon_1 = {eps1}$')  # Пустая линия для легенды
ax.scatter([], [], color='red', label=f'Среда 2: $\\varepsilon_2 = {eps2}$')   # Пустая линия для легенды

# Отображаем границу
ax.axvline(0, color='black', linestyle='--', label="Граница раздела")

# Настроим видимость и параметры линий
ax.set_xlabel("X")
ax.set_ylabel("Y")
ax.set_title(f"Линии напряженностя для границы раздела двух диэлектриков")

# Устанавливаем пределы графика
plt.xlim(-1, 1)
plt.ylim(-1, 1)
plt.legend()
plt.savefig("E")

fig, ax = plt.subplots(figsize=(8, 8))

ax.streamplot(X_1, Y_1, Dx1 * np.ones_like(X_1), Dy1 * np.ones_like(Y_1)) 
ax.streamplot(X_2, Y_2, Dx2 * np.ones_like(X_2), Dy2 * np.ones_like(Y_2)) 

ax.scatter([], [], color='blue', label=f'Среда 1: $\\varepsilon_1 = {eps1}$')  # Пустая линия для легенды
ax.scatter([], [], color='red', label=f'Среда 2: $\\varepsilon_2 = {eps2}$')   # Пустая линия для легенды

# Отображаем границу
ax.axvline(0, color='black', linestyle='--', label="Граница раздела")

# Настроим видимость и параметры линий
ax.set_xlabel("X")
ax.set_ylabel("Y")
ax.set_title(f"Линии Электрического смещения для границы раздела двух диэлектриков")

# Устанавливаем пределы графика
plt.xlim(-1, 1)
plt.ylim(-1, 1)
plt.legend()
plt.savefig("D")
