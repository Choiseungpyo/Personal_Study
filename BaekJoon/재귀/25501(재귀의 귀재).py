def recursion(s, l, r, n):
    n = n+1
    if l >= r:
      return (1,n)
    elif s[l] != s[r]:
      return (0,n)
    return recursion(s, l+1, r-1, n)

def isPalindrome(s):
    return recursion(s, 0, len(s)-1, 0)

n = int(input())
for _ in range(n):
  s = input()
  result = isPalindrome(s)
  print(f"{result[0]} {result[1]}")