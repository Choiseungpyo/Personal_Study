a, b = map(int, input().split())
result = (a+b) * (max(a,b) - min(a,b) +1) // 2 
print(result)