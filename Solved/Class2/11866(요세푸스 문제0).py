import sys
sys.setrecursionlimit(1001)

def josephusPermutation(result, data, n, k):
    if n == 1:
        result.append(data[0])
        return 
    
    if n < k:
        n = k

    for i in range(n):
        num = data.pop(0)
        if i < k-1:
            data.append(num)
        elif i == k-1:
            result.append(num)
            return josephusPermutation(result, data, len(data), k)
    
# Main 
n, k = map(int, input().split())
data = [i for i in range(1, n+1)]
result= []
josephusPermutation(result, data, n, k)

resultLength = len(result)
print("<", end = '')
for i in range(resultLength):
    if i == resultLength - 1:
        print(f"{result[i]}>", end = '')
    else:
        print(f"{result[i]}, ", end = '')