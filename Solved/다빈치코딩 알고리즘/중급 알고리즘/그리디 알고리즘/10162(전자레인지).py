def solve(time):
    if time % 10 != 0:
        print(-1)
        return

    m5 = time // 300
    time %= 300

    m1 = time // 60
    time %= 60

    s10 = time // 10

    print(m5, m1, s10)
    return

T = int(input()) 
solve(T)