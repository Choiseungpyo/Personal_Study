N = int(input())

MAX = 10000
result = MAX
for _ in range(N):
    arrival_time, open_time = map(int, input().split())
    if open_time < arrival_time:
        continue

    if open_time < result:
        result = open_time

if result == MAX:
    result = -1
print(result)
