import sys

n = int(sys.stdin.readline())
for i in range(n):
    data = sys.stdin.readline().rstrip()

    result = "YES"
    c = ""
    totalIndex = 0
    cStartIndex = 0
    while totalIndex < len(data):
        if c == "":
            c = data[totalIndex]
            cStartIndex = totalIndex
            totalIndex+=1
            continue
            
        if data[totalIndex] != c:
            print(f"{i} :   data[{cStartIndex}:{totalIndex}] : {data[cStartIndex:totalIndex]}")
            print(f"{i} :   data[{totalIndex} : {totalIndex + (totalIndex - cStartIndex) + 1}] : {data[totalIndex:totalIndex + (totalIndex - cStartIndex) + 1]}")
            if data[cStartIndex:totalIndex] != data[totalIndex:totalIndex + (totalIndex - cStartIndex) + 1]:
                result = "NO"
                break
            totalIndex = totalIndex + (totalIndex - cStartIndex)
            c = ""
            
        totalIndex+=1
    print(result)