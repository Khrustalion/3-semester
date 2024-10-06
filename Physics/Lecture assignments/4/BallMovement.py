import Ball
import numpy as np


class BallMovement:
    def __init__(self, ball: Ball):
        self.ball = ball

    
    def getGraphic(self):
        ball_1_x = np.linspace(self.ball.x - self.ball.r, self.ball.x + self.ball.r, 1000)
        return ball_1_x, [max(0, (self.ball.r**2 - (self.ball.x - x)**2))**.5 + self.ball.y for x in ball_1_x], [-max(0, (self.ball.r**2 - (self.ball.x - x)**2))**.5 + self.ball.y for x in ball_1_x]


    def updateConflictlSide(self, width, high) -> None:
        if self.ball.x + self.ball.r >= width:
            self.ball.x = width - self.ball.r
            self.ball.speed.v_x *= -1
        elif self.ball.x - self.ball.r <= 0:
            self.ball.x = self.ball.r
            self.ball.speed.v_x *= -1
        elif self.ball.y + self.ball.r >= high:
            self.ball.y = high - self.ball.r
            self.ball.speed.v_y *= -1
        elif self.ball.y - self.ball.r <= 0: 
            self.ball.y = self.ball.r
            self.ball.speed.v_y *= -1
    