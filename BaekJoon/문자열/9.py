# 더 큰 수 반환
def getBiggerN(a, b):
    for i in range(len(a)):
        if a[i] > b[i]:
            return "".join(a)
        elif b[i] > a[i]:
            return "".join(b)

    return "".join(a)
    
# Main
a,b = input().split()
a = [a[i] for i in range(len(a)-1, -1, -1)]
b = [b[i] for i in range(len(b)-1, -1, -1)]
print(getBiggerN(a,b))