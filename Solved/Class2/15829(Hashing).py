l = int(input())
s = input()
r = 31
m = 1234567891
hash = 0

for i in range(l):
    key = (ord(s[i]) - 96)
    hash += key * pow(r, i)
print(hash %  m)