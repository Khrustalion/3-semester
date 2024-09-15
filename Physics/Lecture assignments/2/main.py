import math
import matplotlib.pyplot as plt
import pylab

g = 9.81


def main():
    # v = int(input("Введите начальную скорость в м/с: "))
    #
    # y0 = int(input("Введите начальную высоту в м: "))
    # alpha = int(input("Введите начальный угол в градусах: "))
    v = 60
    y0 = 60
    alpha = 60

    v_x = v * math.cos(alpha * math.pi / 180)

    v_y = v * math.sin(alpha * math.pi / 180)

    t_max = (v_y + (v_y**2 + 2 * g * y0)**.5) / g

    times = [(t_max / 100) * i for i in range(100)]

    x = [t * v_x for t in times]
    y = [y0 + t * v_y - (g * t**2) / 2 for t in times]

    v_y_lst = [v_y - g * t for t in times]

    pylab.subplot(1, 3, 1)
    pylab.title("Траектория движения")
    pylab.xlabel("X, м")
    pylab.ylabel("Y, м")
    pylab.grid(True, linestyle='--')

    pylab.plot(x, y)

    pylab.subplot(1, 3, 2)

    pylab.title("Зависимость координат от времени")
    pylab.xlabel("Время, с")
    pylab.ylabel("Координата, м")

    pylab.plot(times, x, label="Координата Х")
    plt.plot(times, y, label="Координата Y")
    pylab.legend()
    pylab.grid(True, linestyle='--')

    pylab.subplot(1, 3, 3)

    pylab.title("Зависимость скорости от времени")
    pylab.xlabel("Время, с")
    pylab.ylabel("Скорость, м/с")

    pylab.plot(times, v_y_lst, label="Скорость V_y")
    pylab.plot(times, [v_x for _ in range(len(times))], label="Скорость V_x")
    pylab.legend()
    pylab.grid(True, linestyle='--')

    pylab.show()


if __name__ == "__main__":
    main()
