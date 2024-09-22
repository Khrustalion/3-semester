import matplotlib.pyplot as plt
import pandas as pd
from math import ceil
from math import pi, e

file = open("data.txt", "r")

data = [float(x) for x in file]
data_mx = max(data)
data_mn = min(data)

print(data_mn, data_mx)


def format_(n: float) -> str:
    return str(n).replace(".", ",")[:5]


n = len(data)

t_n = sum(data) / n

q = (sum((t_n - x)**2 for x in data) / (n - 1)) ** .5

print(sum((t_n - x)**2 for x in data))

p_max = 1 / (q * (2 * pi)**.5)

t = (data_mx - data_mn) / 5

for i in range(6):
    left = data_mn + t * i
    right = data_mn + t * (i + 1)

    print(format_(left), format_(right), format_((right + left) / 2))

plt.hist(data, color='white', edgecolor='black', bins=5, density=True)

x = [data_mn + (data_mx - data_mn) / 100 * i for i in range(101)]
plt.plot(x, [p_max * e ** (-(t - t_n)**2 / (2 * q**2)) for t in x], label="""Функция плотности распределения\n<t> = 4,99 c\nσ = 0,1129 c""")
plt.grid(True)

plt.xlabel("t, c")
plt.ylabel("ΔN / (N Δt)")
plt.legend(loc=2)
plt.show()


