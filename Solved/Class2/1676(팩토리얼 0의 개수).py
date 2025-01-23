def factorial(n):
    if n == 0:
        return 0
    elif n == 1:
        return 1
    return n * factorial(n-1)

# Main
n = int(input())
n = str(factorial(n))
result = 0

if n == '0':
    print(0)
else:
    for c in n[::-1]:
        if c != '0':
            break
        result += 1
    print(result)