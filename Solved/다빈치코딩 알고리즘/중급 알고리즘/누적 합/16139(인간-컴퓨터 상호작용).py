def get_idx(ch):
    return ord(ch) - ord('a')

def solve(ch, start, end):
    idx = get_idx(ch)
    rst = arr[idx][end]

    if start:
        rst -= arr[idx][start - 1]

    return rst

S = input()
q = int(input())
arr = [[0] * len(S) for _ in range(26)]

for j in range(len(S)):
    idx = get_idx(S[j])
    for i in range(26):
        arr[i][j] = arr[i][j - 1]
        if i == idx:
            arr[i][j] += 1

for _ in range(q):
    ch, start, end = input().split()
    start = int(start)
    end = int(end)
    print(solve(ch, start, end))