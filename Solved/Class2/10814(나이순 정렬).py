import sys

n = int(sys.stdin.readline())
data = {}
for _ in range(n):
    age, name = sys.stdin.readline().split()
    age = int(age)
    
    if age in data:
        data[age].append(name)
    else:
        data[age] = [name]

sortedData = []
for age, names in data.items():
    sortedData.append([age, names])
sortedData.sort()

for data in sortedData:
    for name in data[1]:
        print(f"{data[0]} {name}")