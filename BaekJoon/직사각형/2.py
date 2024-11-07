# 최소 거리 얻기 : 중점으로부터의 거리를 이용
def getMinDist(n, size):
    if n <= size/2:
        return n
    return size - n

x,y,w,h = map(int, input().split())
print(min(getMinDist(x,w), getMinDist(y,h)))