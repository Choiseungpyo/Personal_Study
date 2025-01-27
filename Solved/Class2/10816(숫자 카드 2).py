import sys

sys.stdin.readline()
numCardData = list(map(int, sys.stdin.readline().split()))
sys.stdin.readline()
numCardDataToCheck = list(map(int, sys.stdin.readline().split()))

hash = {}
for num in numCardData:
    if num in hash:
        hash[num] += 1
    else:
        hash[num] = 1

result = ""
for num in numCardDataToCheck:
    if num in hash:
        print(hash[num], end = ' ')
    else:
        print(0, end = ' ')
