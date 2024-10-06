import matplotlib.pyplot as plt
import matplotlib.animation as animation
import numpy as np
from math import pi, cos, sin
import time


r = int(input("Введите радиус окружености в м: "))
v = int(input("Введите скорость материальной точки в м/c: "))

delta = 4 * pi * r / 100

fig, ax = plt.subplots()
x_coord_point = np.array([x + r * sin(x / r) for x in np.linspace(0, 4 * pi * r, 100)])
y_coord_point = np.array([r + r * cos(x / r) for x in np.linspace(0, 4 * pi * r, 100)])


trace_point = ax.plot(x_coord_point, y_coord_point)[0]

point = ax.plot([x_coord_point[0]], [y_coord_point[0]], 'ro')[0]

x_coord_circle = np.linspace(-r, r, 100)
y_coord_circle_up = [(r**2 - x**2)**.5 + r for x in x_coord_circle]
y_coord_circle_down = [-y + 2 * r for y in y_coord_circle_up]

trace_circle_up = ax.plot(x_coord_circle, y_coord_circle_up, color='black')[0]
trace_circle_down = ax.plot(x_coord_circle, y_coord_circle_down, color='black')[0]

timer_text = ax.text(0.01, 0.95, '', fontsize=12, ha='left', va='top', transform=ax.transAxes)

start_time = time.time()


def update(frame):
    x_point = x_coord_point[:frame]
    y_point = y_coord_point[:frame]

    trace_point.set_data(x_point, y_point)

    x_circle = np.linspace(-r + delta*frame, r + delta*frame, 100)
    y_circle_up = [max((r**2 - (x - delta*frame)**2), 0)**.5 + r for x in x_circle]
    y_circle_down = [-y + 2 * r for y in y_circle_up]

    trace_circle_up.set_data(x_circle, y_circle_up)
    trace_circle_down.set_data(x_circle, y_circle_down)

    point.set_data([x_coord_point[max(frame-1, 0)]], [y_coord_point[max(frame-1, 0)]])
    t = time.time() - start_time
    timer_text.set_text(f'Time: {t:.1f} s')

    return trace_point, trace_circle_up, point, timer_text


ani = animation.FuncAnimation(fig=fig, func=update, frames=101, interval=(4 * pi * r * 10 // v))
plt.ylim(0, 4 * pi * r)

plt.xlabel("X, м")
plt.ylabel("Y, м")
plt.show()
