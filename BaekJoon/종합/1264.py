import sys
vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U']
while True:
    s = sys.stdin.readline().rstrip()
    if s == '#':
        break
    
    cnt = 0
    for vowel in vowels:
        cnt += s.count(vowel)
    print(cnt)