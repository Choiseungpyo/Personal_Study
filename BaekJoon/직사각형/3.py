# storage 세팅하기
def setStorage(n, lst):
    if n in lst:
        lst.remove(n)
    else:
        lst.append(n)

storage =[[],[]]
for _ in range(3):
    x,y = list(input().split())
    setStorage(x, storage[0])
    setStorage(y, storage[1])

print(storage[0][0] + ' ' + storage[1][0])