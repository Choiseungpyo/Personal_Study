N = int(input())
number = 666
answer = number

while N - 1:
    number += 1
    if '666' in str(number):
        answer = number
        N -= 1
        
print(number)