import numpy as np
import matplotlib.pyplot as plt

# Константы
k = 1  # Коэффициент пропорциональности

# Определение зарядов

n = int(input("Введите количество зарядов: "))

charges = []

x_min, x_max = float('inf'), -float('inf')
y_min, y_max = float('inf'), -float('inf')

for _ in range(n):
    q = int(input(f"Введите величину {_ + 1} заряда в Кл: "))
    x, y = [int(x) for x in input(f"Введите координаты {_ + 1} заряда через пробел: ").split()]

    x_min, x_max = min(x_min, x - 1), max(x_max, x + 1)
    y_min, y_max = min(y_min, y - 1), max(y_max, y + 1)

    charges.append({"q" : q, "pos" : (x, y)})



# Параметры области
resolution = max(y_max - y_min, x_max - x_min) * 5 # Количество векторов по каждой оси

# Создание сетки
x = np.linspace(x_min, x_max, resolution)
y = np.linspace(y_min, y_max, resolution)
X, Y = np.meshgrid(x, y)

# Расчёт электрического поля
Ex, Ey = np.zeros(X.shape), np.zeros(Y.shape)
abs_E = np.zeros(X.shape)
for charge in charges:
    q = charge["q"]
    cx, cy = charge["pos"]
    dx = X - cx
    dy = Y - cy
    r_squared = dx**2 + dy**2
    r_squared[r_squared == 0] = 1e-10  # Избегаем деления на 0
    Ex += k * q * dx / r_squared**1.5
    Ey += k * q * dy / r_squared**1.5

# Визуализация
magnitude = np.sqrt(Ex**2 + Ey**2)

Ex /= magnitude  # Нормализация для векторов
Ey /= magnitude
magnitude[magnitude > 50 * magnitude.min()] = 50 * magnitude.min()

plt.figure(figsize=(10, 8))
quiver_plot = plt.quiver(X, Y, Ex, Ey, magnitude, cmap='Set1', scale=30)
for charge in charges:
    plt.scatter(charge['pos'][0], charge['pos'][1], c = 'red' if charge['q']>=0 else 'blue', s=100)

plt.xlabel("x")
plt.ylabel("y")
plt.title("Electric Field Visualization")
plt.grid()
plt.show()
