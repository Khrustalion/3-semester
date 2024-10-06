import Speed
import numpy as np

class Ball:
    def __init__(self, r: float, x: float, y: float, m: float,  speed: Speed) -> None:
        self.r = r
        self.x = x
        self.y = y
        self.m = m
        self.speed = speed

