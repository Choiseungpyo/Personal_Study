n = input()
nData = set(input().split())
m = input()
mData = list(input().split())
for i in mData:
    result = 0
    if i in nData:
        result = 1
    print(result , end=' ')