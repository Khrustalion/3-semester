import numpy as np
import matplotlib.pyplot as plt

class Gravitational:
    def __init__(self, x, y, G, m1, m2):
        self.x = x
        self.y = y
        self.G = G
        self.m1 = m1
        self.m2 = m2


    def get_potential(self):
        R = np.sqrt(self.x**2 + self.y**2)
        U = -G * self.m1 * self.m2 / R
        U[np.isinf(U)] = np.nan
        return U

class Elastic:
    def __init__(self, x, y, k):
        self.x = x
        self.y = y
        self.k = k


    def get_potential(self):
        R = np.sqrt(self.x**2 + self.y**2)
        U = 0.5 * self.k * R**2
        return U

class Weight:
    def __init__(self, y, m):
        self.y = y
        self.m = m
        self.g = 9.81


    def get_potential(self):
        U = self.m * self.g * self.y
        return U

class Unknown:
    def __init__(self, x, y, a, b, c, d):
        self.x = x
        self.y = y
        self.a = a
        self.b = b
        self.c = c
        self.d = d


    def get_potential(self):
        U = self.a * (self.x**(self.b + 1) / (self.b + 1)) + self.c * (self.y**(self.d + 1) / (self.d + 1))
        return U

# Настройка сетки координат
x = np.linspace(-10, 10, 500)
y = np.linspace(-10, 10, 500)
X, Y = np.meshgrid(x, y)

# Выбор силы
print("Выберите силу для моделирования потенциального поля:")
print("1. Гравитационная сила")
print("2. Сила упругости")
print("3. Сила тяжести")
print("4. Неизвестная сила (степенная функция)")
choice = int(input("Введите номер выбора: "))

# Ввод параметров и расчет потенциала в зависимости от выбора
if choice == 1:
    G = float(input("Введите гравитационную постоянную G: "))
    m1 = float(input("Введите массу источника гравитации m1: "))
    m2 = float(input("Введите массу тела m2: "))
    Force = Gravitational(X, Y, G, m1, m2)
elif choice == 2:
    k = float(input("Введите коэффициент упругости k: "))
    Force = Elastic(X, Y, k)
elif choice == 3:
    m = float(input("Введите массу тела m: "))
    Force = Weight(Y, m)
elif choice == 4:
    a = float(input("Введите коэффициент a: "))
    b = float(input("Введите показатель степени b: "))
    c = float(input("Введите коэффициент c: "))
    Force = Unknown(X, Y, a, b, c)
else:
    print("Неверный выбор")
    exit()

U = Force.get_potential()

# Визуализация
plt.figure(figsize=(8, 6))
plt.contourf(X, Y, U, levels=100, cmap='viridis')
plt.colorbar(label='Потенциальная энергия U(x, y)')
plt.title("Двумерное распределение потенциальной энергии")
plt.xlabel("x")
plt.ylabel("y")
plt.show()
