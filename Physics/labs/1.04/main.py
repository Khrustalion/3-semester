import matplotlib.pyplot as plt
import numpy as np


def getData(file_name: str, n: int):
    lst = [[] for i in range(6)]
    with open(file_name) as file:
        for _ in range(n):
            for i in range(6):
                lst[i].append(float((file.readline().replace(",", "."))))

    return lst

def main():
    M = getData("M.txt", 4)
    M_avg = [sum(x) / 4 for x in M]
    e = getData("e.txt", 4)
    e_avg = [sum(x) / 4 for x in e]
    I = list(zip(*getData("I.txt", 1)))[0]
    I_avg = sum(I) / 6
    R = list(zip(*getData("R.txt", 1)))[0]
    R_avg = sum(R) / 6
    R_2 = [x**2 for x in R]
    R_2_avg = sum(R_2) / 6
    I_0 = (I_avg - 1.871110197*R_2_avg)
    M_tr = [M_avg[i] - I[i]*e_avg[i] for i  in range(6)]
    I_MNK = [0.0082 + 1.871110197 * R_2[i] for i in range(6)]
    d = [I[i] - I_MNK[i] for i in range(6)]
    d_2 = [x**2 for x in d]
    print(sum(d_2))
    D = sum([(R[i] - R_avg)**2 for i in range(6)])
    S_I0 = ((1/6 + R_2_avg**2 / D) * (sum(d_2) / 4))**.5

    print(S_I0)
    S_4m = (1/D * (sum(d_2)/4))**.5
    print(S_4m)
    

    for i in range(6):
        plt.scatter(e[i], M[i], color="orange")
        plt.plot(e[i], [M_tr[i] + I[i]*e[i][j] for j in range(4)], label=f"количество рисок: {i+1}")
        plt.title(f"количество рисок: {i+1}")
        plt.grid()
        plt.ylabel("M, H * м")
        plt.xlabel("e, c^(-2)")
    plt.legend()
    plt.grid()
    plt.show()
    plt.scatter(R_2, I, color="orange")
    plt.plot(R_2, I, color="orange", label="Экспериментальные точки")
    plt.plot(R_2, I_MNK, label="МНК по Экспериментальным точкам")
    plt.ylabel("I, кг * м^2")
    plt.xlabel("R^2, м^2")
    plt.ylim(0, 0.09)
    plt.xlim(0, 0.045)
    plt.grid()
    plt.legend()
    plt.show()


if __name__ == "__main__":
    main()