input()
numCardData = input().split()
input()
numCardDataToCheck = input().split()
result = ""
for num in numCardDataToCheck:
    print(numCardData.count(num), end = ' ')
