n, x =  input().split(' ')
x = int(x)
result = 0

if int(n) < x :
    print(n)
else:
    for i in range(len(n)-1, -1, -1):
        num = 0
        if n[i].isalpha():
            num = ord(n[i]) - 55
        else:
            num = int(n[i])
        result += num * pow(x,len(n) - i -1)
        print(f"{result} += {num} * pow({x}, {i})")           

    print(result)  