from Simulation import Simulation
from Ball import Ball
from BallMovement import BallMovement
from Speed import Speed
import matplotlib.pyplot as plt
import numpy as np
import matplotlib.animation as animation


dt = 0.025

m1 = float(input("Введите массу первого тела в кг: "))
v1_x, v1_y = [float(x) for x in input(r"Введите модуль-вектор через пробел скорости первого тела в м/с: ").split()]

v1 = Speed(v1_x, v1_y)

m2 = float(input("Введите массу второго тела в кг: "))
v2_x, v2_y = [float(x) for x in input(r"Введите модуль-вектор через пробел скорости второго тела в м/с: ").split()]
m2 = 20
v2_x, v2_y = -20, 20
v2 = Speed(v2_x, v2_y)

width, high = [int(x) for x in input("Введите ширину и длину области в м: ").split()]

width, high = 100, 100


r = max(width, high) // 50

simulation = Simulation(width, high)

n = 2

simulation.addBall(BallMovement(Ball(r, r + 1, r + 1, m1, v1)))
simulation.addBall(BallMovement(Ball(r, width - r - 1, r + 1, m2, v2)))

fig, ax = plt.subplots()

ax.plot(np.linspace(0, width, width * 100), [high] * (width * 100), color='black')
ax.plot([width] * (high * 100), np.linspace(0, high, high * 100), color='black')
ax.plot(np.linspace(0, width, width * 100), [0] * (width * 100), color='black')
ax.plot([0] * (high * 100), np.linspace(0, high, high * 100), color='black')

balls_up = [0 for i in range(n)]
balls_down = [0 for i in range(n)]

for i in range(len(simulation.balls)):
    ball = simulation.balls[i]
    ball_coords = ball.getGraphic()

    balls_up[i] = ax.plot(ball_coords[0], ball_coords[1], color='black')[0]
    balls_down[i] = ax.plot(ball_coords[0], ball_coords[2], color='black')[0]


def update(frame):
    simulation.simulate(dt)

    for i in range(len(simulation.balls)):
        ball = simulation.balls[i]
        ball_coords = ball.getGraphic()

        balls_up[i].set_data(ball_coords[0], ball_coords[1])
        balls_down[i].set_data(ball_coords[0], ball_coords[2])

    return *balls_up, *balls_down



ax.axis('equal')
ani = animation.FuncAnimation(fig=fig, func=update, interval=0)
plt.show()
