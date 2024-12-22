s = input()
mobis = ['M', 'O', 'B', 'I', 'S']
result = "YES"
for c in mobis:
    if s.find(c) == -1:
        result = "NO"
        break
print(result)