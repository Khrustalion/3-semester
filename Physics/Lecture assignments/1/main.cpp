#include <math.h>
#include <iostream>

void input(double& x, double& y, double& z, int& precision) {
    std::cout << "Input X: ";
    std::cin >> x;
    std::cout << "Input Y: ";
    std::cin >> y;
    std::cout << "Input Z: ";
    std::cin >> z;
    std::cout << "Input precision: ";
    std::cin >> precision;

    precision = std::pow(10, precision);
}

void spheres_coord(double x, double y, double z, int precision) {
    double r = round(sqrt(x*x + y*y + z*z) * precision) / precision;
    double theta = round(atan(sqrt(x * x + y * y) / z) * precision) / precision;
    double phi = round(atan(y / x) * precision) / precision;

    std::cout << "R: " << r << '\n';
    std::cout << "Theta: " << theta << '\n';
    std::cout << "Phi: " << phi << '\n';
}

int main() {
    double x, y, z;
    int precision;

    input(x, y, z, precision);
    spheres_coord(x, y, z, precision);
}