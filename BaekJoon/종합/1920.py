import sys
n = sys.stdin.readline()
storage = []
storage = list(sys.stdin.readline().split())
m = int(sys.stdin.readline().rstrip())
data = list(sys.stdin.readline().split())
s = ""
dataLength = len(data)
for i in range(dataLength):
    result = 0
    if data[i] in storage:
        result = 1
        
    s += f"{result}"
    if i != dataLength -1:
        s += "\n"
print(s)