# 과목 평점 얻기
def getSubjectAvg(rank):
    if rank == 'A+':
        return 4.5
    elif rank == 'A0':
        return 4.0
    elif rank == 'B+':
        return 3.5
    elif rank == 'B0':
        return 3.0
    elif rank == 'C+':
        return 2.5
    elif rank == 'C0':
        return 2.0
    elif rank == 'D+':
        return 1.5
    elif rank == 'D0':
        return 1.0
    elif rank == 'F':
        return 0.0
    else : # P
        return None

# Main
sum = 0
creditSum = 0

for i in range(20):
    subjectName, credit, rank = input().split(' ')
    subjectAvg =  getSubjectAvg(rank)
    if subjectAvg == None:
        continue
    
    credit = float(credit)
    creditSum += credit
    sum += credit * subjectAvg
    
result = sum / creditSum
print(round(result, 6))