import sys

class Queue:
  def __init__(self):
    self.s = []

  def push(self, x : int):
    self.s.append(x)

  def pop(self):
    result = -1
    if self.__size() > 0:
      result = self.s.pop(0)
    print(result) 

  def __size(self):
    return len(self.s)

  def size(self):
    print(self.__size())

  def empty(self):
    result = 1
    if self.s:
      result = 0
    print(result)

  def front(self):
    result = -1
    if self.__size() != 0:
      result = self.s[0]
    print(result)

  def back(self):
    result = -1
    if self.__size() != 0:
      result = self.s[-1]
    print(result)

# Main
q = Queue()
n = int(sys.stdin.readline())
for i in range(n):
  s = list(sys.stdin.readline().split())
  if s[0] == "push":
    q.push(int(s[1]))
  elif s[0] == "pop":
    q.pop()
  elif s[0] == "size":
    q.size()
  elif s[0] == "empty":
    q.empty()
  elif s[0] == "front":
    q.front()
  elif s[0] == "back":
    q.back()