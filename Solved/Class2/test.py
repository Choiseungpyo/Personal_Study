import sys
input=sys.stdin.readlines
def lineUp():
    memberList=input()[1:]
    memberList.sort(key=lambda age: int(age.split()[0]))
    print("".join(memberList))
lineUp()