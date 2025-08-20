import numpy as np
import matplotlib.pyplot as plt

# Константы
k = 9e9  # Коэффициент (в реальности — 1/(4πε₀))

# Определение зарядов: [x, y, величина заряда]
charges = []

n = int(input("Введите количество зарядов: "))

for _ in range(n):
    x, y = [int(x) for x in input("Введите координаты (x, y) через пробел: ").split()]
    charge = int(input("Введите величину заряда в Кл: "))

    charges.append([x, y, charge])

left = min([min(charge[0:2]) for charge in charges] + [-1]) * 2
right = max([max(charge[0:2]) for charge in charges] + [1]) * 2

# Сетка для расчета
x = np.linspace(-max(abs(left), right), max(abs(left), right), 500)
y = x
X, Y = np.meshgrid(x, y)

# Вычисление потенциала
V = np.zeros_like(X)
Ex, Ey = np.zeros_like(X), np.zeros_like(Y)

for charge in charges:
    cx, cy, q = charge
    R = np.sqrt((X - cx)**2 + (Y - cy)**2)
    V += k * q / R  # Потенциал
    Ex += k * q * (X - cx) / R**3  # Компонента поля по x
    Ey += k * q * (Y - cy) / R**3  # Компонента поля по 

V //= max(abs(charge[2]) * 1e9 for charge in charges)
V[V > 17] = 17
V[V < -17] = -17

# Визуализация
# plt.figure(figsize=(10, 8))

# Эквипотенциальные линии
im = plt.imshow(
    V, extent=[X.min(), X.max(), Y.min(), Y.max()], origin="lower", cmap="Spectral_r"
)

# Линии напряженности
plt.streamplot(X, Y, Ex, Ey, color=np.sqrt(Ex**2 + Ey**2), cmap="inferno", linewidth=0.8)

for charge in charges:
    cx, cy, q = charge
    color = 'red' if q > 0 else 'blue'
    plt.scatter(cx, cy, color=color, s=30, label=f"{'+q' if q > 0 else '-q'}")



plt.title("Эквипотенциальные линии и линии напряженности")
plt.xlabel("x (м)")
plt.ylabel("y (м)")
plt.legend(loc="upper right")
plt.grid(alpha=0.3)
plt.xlim(left, right)
plt.ylim(left, right)
plt.show()