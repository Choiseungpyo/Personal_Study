N, K = map(int, input().split())

arr = list(map(int, input().split()))
result = sum(arr[:K])

temp = result
    temp += arr[i] - arr[i-K]
    result = max(result, temp)

print(result)