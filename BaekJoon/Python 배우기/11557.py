import sys
t = int(input())
result = {'name' : "", "l" :0}
for _ in range(t):
    n = int(input())
    for i in range(n):
        name, l = sys.stdin.readline().split()
        l = int(l)
        if l > result['l']:
            result['name'] = name
            result['l'] = l
    print(result['name'])