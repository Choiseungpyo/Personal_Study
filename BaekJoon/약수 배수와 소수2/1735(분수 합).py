def GCD(x, y):
    while y:
        x, y = y, x%y
    return x

a1, a2 = map(int, input().split())
b1, b2 = map(int, input().split())
a1 = (a1 * b2 + a2 * b1)
a2 = a2 * b2
gcd = GCD(a2, a1)
print(f"{a1//gcd} {a2//gcd}")