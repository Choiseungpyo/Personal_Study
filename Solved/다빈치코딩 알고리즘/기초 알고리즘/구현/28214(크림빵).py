def mii():
    return map(int, input().split()) 

N, K, P = mii()
arr = tuple(mii())

start = 0
end = K
ans = 0
for _ in range(N):
    cnt = K - sum(arr[start:end])
    if cnt < P:
        ans += 1
    start = end
    end += K
print(ans)