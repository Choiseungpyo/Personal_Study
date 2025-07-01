import heapq
import sys 

input = sys.stdin.readline
N = int(input())
heap = []

for _ in range(N):
    x = int(input())

    if x:
        heapq.heappush(heap, -x)
    else:
        result = 0
        if len(heap):
            result = -heapq.heappop(heap)      
        print(result)