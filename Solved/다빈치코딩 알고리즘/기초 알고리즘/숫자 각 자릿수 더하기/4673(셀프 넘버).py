def d(n:int):
    for c in str(n):
        n += int(c)
    return n

# Main
MAX = 10001
isSelfNum = [True] * MAX
for i in range(1, MAX):
    result = d(i)
    
    if result < MAX:
        isSelfNum[result] = False
        
for i in range(1, MAX):
    if isSelfNum[i]:
        print(i)