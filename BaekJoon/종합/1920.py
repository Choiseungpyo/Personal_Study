import sys
sys.stdin.readline()
data = sys.stdin.readline().split()
sys.stdin.readline()
dataToCheck = sys.stdin.readline().split()

hash = {}
for num in data:
    hash[num] = 1

for num in dataToCheck:
    if num in hash:
        print(1)
    else:
        print(0)