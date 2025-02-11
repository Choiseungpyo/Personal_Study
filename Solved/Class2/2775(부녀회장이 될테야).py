from sys import stdin

t = int(stdin.readline())

for _ in range(t):
    k = int(stdin.readline())
    n = int(stdin.readline())

    numOfPeople={}
    
    for i in range(1, n+1):
        numOfPeople[i] = i
        
    for floor in range(k):    
        for room in range(2, n+1):
            numOfPeople[room] = numOfPeople[room-1] + numOfPeople[room]
 
    print(numOfPeople[n])