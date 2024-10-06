import BallMovement
import Ball


class Simulation:
    def __init__(self,  width, high):
        self.width = width
        self.high = high

        self.balls : BallMovement = []

    def addBall(self, ball: BallMovement) -> None:
        self.balls.append(ball)


    def isConflict(self, ball_1: Ball, ball_2: Ball) -> bool:
        return ((ball_1.x - ball_2.x)**2 + (ball_1.y - ball_2.y)**2)**.5 <= (ball_1.r + ball_2.r)
    

    def solveConflict(self, ball_1: Ball, ball_2: Ball) -> None:
        hypotenuse = (ball_1.x**2 + ball_1.y**2)**.5
        sin_a = ball_1.y / hypotenuse
        cos_a = ball_1.x / hypotenuse

        delta_x = (ball_1.r + ball_2.r) - ((ball_1.x - ball_2.x)**2 + (ball_1.y - ball_2.y)**2)**.5

        ball_1.x += delta_x * cos_a * ball_1.r / (ball_1.r + ball_2.r)
        ball_1.y +=  delta_x * sin_a * ball_1.r / (ball_1.r + ball_2.r)

        ball_2.x += delta_x * cos_a * ball_2.r / (ball_1.r + ball_2.r)
        ball_2.y += delta_x * sin_a * ball_2.r / (ball_1.r + ball_2.r)


        new_ball_1_v_x = ((ball_1.m - ball_2.m) * ball_1.speed.v_x + 2 * ball_2.m * ball_2.speed.v_x) / (ball_1.m + ball_2.m)
        new_ball_1_v_y = ((ball_1.m - ball_2.m) * ball_1.speed.v_y + 2 * ball_2.m * ball_2.speed.v_y) / (ball_1.m + ball_2.m)

        new_ball_2_v_x = ((ball_2.m - ball_1.m) * ball_2.speed.v_x + 2 * ball_1.m * ball_1.speed.v_x) / (ball_1.m + ball_2.m)
        new_ball_2_v_y = ((ball_2.m - ball_1.m) * ball_2.speed.v_y + 2 * ball_1.m * ball_1.speed.v_y) / (ball_1.m + ball_2.m)

        ball_1.speed.v_x = new_ball_1_v_x
        ball_1.speed.v_y = new_ball_1_v_y

        ball_2.speed.v_x = new_ball_2_v_x
        ball_2.speed.v_y = new_ball_2_v_y

    
    def simulate(self, precision: float) -> None:
        for ball in self.balls:
            ball.ball.x += ball.ball.speed.v_x * precision
            ball.ball.y += ball.ball.speed.v_y * precision

        for i in range(len(self.balls)):
            for j in range(i + 1, len(self.balls)):
                ball_1 = self.balls[i].ball
                ball_2 = self.balls[j].ball
                if (self.isConflict(ball_1, ball_2)):
                    self.solveConflict(ball_1, ball_2)

        for ball in self.balls:
            ball.updateConflictlSide(self.width, self.high)

