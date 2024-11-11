storage =[]
for i in range(3):
    storage.append(int(input()))

sum = 0
for i in storage:
    sum += i

result = "Error"
if sum == 180:
    if storage[0] == storage[1] and storage[0] == storage[2]:
        result = "Equilateral"
    elif storage[0] == storage[1] or storage[0] == storage[2] or storage[1] == storage[2]:
        result = "lsosceles"
    else:
        result = "Scalene"
print(result)