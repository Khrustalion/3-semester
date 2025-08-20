from scipy.integrate import quad
from math import e

def f(x):
    return (1 - e**(-2*x))/(x)

print(quad(f, 0, 0.1))