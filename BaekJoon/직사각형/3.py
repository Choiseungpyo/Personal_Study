# storage =[]
# for i in range(3):
#     storage.append(list(map(int, input().split())))

# # 1,2번째 점의 x 값이 같은 경우(=3,4번째 점의 x가 같음)
# if storage[0][0] == storage[1][0]:
#     # 1,3 번째의 y 값이 같은 경우
#     if storage[2][1] == storage[0][1]: 
#         storage.append([storage[2][0], storage[1][1]])
#     else:
#         storage.append([storage[2][0], storage[0][1]])
# # 1,3번째 점의 x 값이 같은 경우
# elif storage[0][1] == storage[1][1]:
#     # 1,3 번째의 x값이 같은 경우(3,4번째 점의 y가 같음)
#     if storage[0][0] == storage[2][0]: 
#         storage.append([storage[1][0], storage[2][1]])
#     else:
#         storage.append([storage[0][0], storage[2][1]])
# print(' '.join(f"{i}" for i in storage[3]))

storage =[]
for _ in range(3):
    tmp = list(input().split())
    print(tmp)
    for i in tmp:
        if i in storage:
            storage.remove(i)
        else:
            storage.append(i)
    print(storage)

print(storage)