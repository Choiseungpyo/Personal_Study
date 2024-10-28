n = 9
storage = [list(map(int, input().split())) for _ in range(n)]
data = {'max' :{'value' : -1, 'index' : "-1 -1"}}
for row in range(n):
    for col in range(n):
        if storage[row][col] > data['max']['value']:
            data['max']['value'] = storage[row][col]
            data['max']['index'] = f"{row+1} {col+1}"
print(f"{data['max']['value']}\n{data['max']['index']}")