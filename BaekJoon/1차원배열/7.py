# 출석부 설정
def setAttendanceBook(maxStudentNum, submittedStudentNum):
    attendanceBook = []
    unsubmittedStudentBook = []
    minNum = maxStudentNum+1

    for i in range(submittedStudentNum):
        x = int(input())
        if x < 1 or x > maxStudentNum :
            print("값의 범위가 올바르지 않습니다.")
            return
        if attendanceBook.count(x) == 0:
            attendanceBook.append(x)
        else:
            print("이미 입력한 값입니다.") 
            return
    
    attendanceBook.sort()

    for i in range(1, maxStudentNum+1):
        if attendanceBook.count(i) == 0:
            unsubmittedStudentBook.append(i)
            if i < minNum: 
                minNum  = i
    
    print(minNum)
    for i in unsubmittedStudentBook:
        if minNum == i:
            continue
        print(i)
    

# Main
setAttendanceBook(30, 28)