T = int(input())
for _ in range(T):
    ps = input()
    stack = []
    check = False
    for s in ps:
        if s == "(":
            stack.append(s)
        else:
            if not stack:
                check = True
                break
            stack.pop()
    result = "YES"
    if stack or check:
        result = "NO"
    print(result)