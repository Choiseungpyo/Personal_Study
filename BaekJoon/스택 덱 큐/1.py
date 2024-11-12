import sys

def insert(stack, x : int):
    stack.append(x)
          
def printLastAndPop(stack : list):
    if len(stack) == 0:
        print(-1)
    else:
        print(stack.pop())
    
def printSize(stack):
    print(len(stack))
        
def printIsEmpty(stack):
    print(1 if len(stack) == 0 else 0)
        
def printLast(stack):
    if len(stack) == 0:
        print(-1)
    else:
        print(stack[-1])

stack = [] 
n = int(input())



for i in range(n):
    inputStorage = list(map(int, sys.stdin.readline().split()))
    if inputStorage[0] == 1:
        insert(stack, inputStorage[1])
    elif inputStorage[0] == 2:
        printLastAndPop(stack)
    elif inputStorage[0] == 3:
        printSize(stack)
    elif inputStorage[0] == 4:
        printIsEmpty(stack)
    elif inputStorage[0] == 5:
        printLast(stack)