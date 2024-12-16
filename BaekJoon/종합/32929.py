i = int(input())
i = (i-1) % 3
result = 'S'
if i == 0:
    result = 'U'
elif i == 1:
    result = 'O'
print(result)