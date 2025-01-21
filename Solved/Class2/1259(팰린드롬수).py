import sys 
while True:
    s = sys.stdin.readline().rstrip()
    if s=='0':
        break
    result = 'yes'
    for i in range(len(s)//2):
        if s[i] != s[-1-i]:
            result = 'no'
            break
    print(result)