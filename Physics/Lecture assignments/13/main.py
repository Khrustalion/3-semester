import numpy as np
import matplotlib.pyplot as plt

k = 9e9

charges = []

n = int(input("Введите количество зарядов: "))

for _ in range(n):
    x, y = [float(x) for x in input("Введите координаты (x, y) через пробел: ").split()]
    charge = float(input("Введите величину заряда в Кл: "))
    charges.append([x, y, charge])

dipole_position = np.array([float(x) for x in input("Введите координату полжительного заряда диполя (x, y) через пробел: ").split()])
dipole_charge = abs(float(input("Введите величину одного из зарядов диполя: ")))
dipole_moment = np.array([float(x) for x in input("Введите дипольный момент (x, y) через пробел: ").split()])

left = min([min(charge[0:2]) for charge in charges] + [-1]) * 2
right = max([max(charge[0:2]) for charge in charges] + [1]) * 2

x = np.linspace(-max(abs(left), right), max(abs(left), right), 500)
y = x
X, Y = np.meshgrid(x, y)

V = np.zeros_like(X)
Ex, Ey = np.zeros_like(X), np.zeros_like(Y)

Ex_without_dipole, Ey_without_dipole = Ex, Ey

for charge in charges:
    cx, cy, q = charge
    R = np.sqrt((X - cx)**2 + (Y - cy)**2)
    Ex_without_dipole += k * q * (X - cx) / R**3
    Ey_without_dipole += k * q * (Y - cy) / R**3

charges.append([*dipole_position, dipole_charge])
charges.append([*(dipole_position + dipole_moment / dipole_charge), -dipole_charge])

for charge in charges:
    cx, cy, q = charge
    R = np.sqrt((X - cx)**2 + (Y - cy)**2)
    V += k * q / R
    Ex += k * q * (X - cx) / R**3
    Ey += k * q * (Y - cy) / R**3

V //= max(abs(charge[2]) * 1e9 for charge in charges)
V[V > 17] = 17
V[V < -17] = -17

dipole_E = np.array([
    np.interp(dipole_position[0], x, Ex_without_dipole[:, len(x)//2]),
    np.interp(dipole_position[1], y, Ey_without_dipole[len(y)//2, :])
])

force = np.dot(dipole_moment, np.gradient(dipole_E))
torque = np.cross(dipole_moment, dipole_E)

im = plt.imshow(
    V, extent=[X.min(), X.max(), Y.min(), Y.max()], origin="lower", cmap="Spectral_r"
)

plt.streamplot(X, Y, Ex, Ey, color=np.sqrt(Ex**2 + Ey**2), cmap="inferno", linewidth=0.8)

label = [False, False]

for charge in charges:
    cx, cy, q = charge
    color = 'red' if q > 0 else 'blue'
    if q >= 0 and not label[0]:
        plt.scatter(cx, cy, color=color, s=30, label=f"{'+q' if q > 0 else '-q'}")
        label[0] = True
    if q < 0 and not label[1]:
        plt.scatter(cx, cy, color=color, s=30, label=f"{'+q' if q > 0 else '-q'}")
        label[1] = True
    else:
        plt.scatter(cx, cy, color=color, s=30)


plt.title("Эквипотенциальные линии и линии напряженности с диполем")
plt.xlabel("x (м)")
plt.ylabel("y (м)")
plt.legend(loc="upper right")
plt.grid(alpha=0.3)
plt.xlim(left, right)
plt.ylim(left, right)
plt.show()

print("Сила на диполь:", force)
print("Момент на диполь:", torque)