cnt = int(input())
rectangleStorage = [list(map(int, input().split(' '))) for _ in range(cnt)]
scale = 10
overlapResult = 0

for ori in rectangleStorage:
    for obj in rectangleStorage:
        #자기 자신인 경우
        if ori == obj:
            break
        
        # 안 겹치는 경우
        if obj[0] + scale <= ori[0] or ori[0] + scale <= obj[0]:
            continue
        if obj[1] + scale <= ori[1] or ori[1] + scale <= obj[1]:
            continue
        
        #겹치는 경우
        overlapResult += (scale - abs(ori[0] - obj[0])) * (scale - abs(ori[1] - obj[1]))

print(scale * scale * cnt - overlapResult)        