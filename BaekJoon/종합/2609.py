def GCD(a, b):
    while b != 0:
        a, b = b, a%b
    return a

a, b = map(int, input().split())
gcd = GCD(a,b)
print(gcd, b * a // gcd)