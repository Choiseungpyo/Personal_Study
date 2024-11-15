def setLines(lines, tmpLines, currNum):
    copyLines = lines.copy()
    for i in copyLines:
        if i == currNum:
            lines.pop(0)
            break
        tmpLines.append(lines.pop(0))     
    currNum+=1
    return currNum

def setTmpLines(tmpLines, currNum):
    if tmpLines[-1] != currNum:
        return -1
    tmpLines.pop()
    currNum +=1
    return currNum

# Main
currNum = 1
result = "Nice"
n = int(input())
lines = list(map(int, input().split())) 
tmpLines= []

while currNum < n:
    if currNum in lines:
        currNum = setLines(lines, tmpLines, currNum)
    else:
        currNum = setTmpLines(tmpLines, currNum)
        if currNum == -1:
            result = "Sad"
            break 
print(result)