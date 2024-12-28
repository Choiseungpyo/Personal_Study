storage = list(map(int, input().split()))
sum = 0
for i in storage:
    sum += pow(i, 2)
print(sum%10)