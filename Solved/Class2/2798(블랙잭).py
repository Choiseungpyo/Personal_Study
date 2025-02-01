from sys import stdin

def getBlackJackResult(card, n):
    sums = []
    for a in range(n-1, -1, -1):
        for b in range(a-1, 0, -1):
            for c in range(b-1, -1, -1):
                sum = cards[a] + cards[b] + cards[c]
                if sum == m:
                    return sum
                elif sum < m:
                    sums.append(sum)
    sums.sort()
    return sums[-1]

# Main
n,m = map(int, stdin.readline().split())
cards = list(map(int, stdin.readline().split()))
result = getBlackJackResult(cards, n)
print(result)