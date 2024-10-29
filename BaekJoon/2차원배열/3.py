cnt = 5
storage = [[c for c in input()] for _ in range(cnt)]
for charIndex in range(15):
    for storageIndex in range(cnt):
        if charIndex >= len(storage[storageIndex]):
            continue
        print(storage[storageIndex][charIndex], end='')