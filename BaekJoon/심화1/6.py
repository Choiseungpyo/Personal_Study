croatiaAlphaSet = ['c=', 'c-', 'dz=', 'd-', 'lj', 'nj', 's=', 'z=']
s = input()
i = cnt = 0
flag = False
    
while flag == False:
    if s.find(croatiaAlphaSet[i]) != -1:
        s = s.replace(croatiaAlphaSet[i], ' ')
        cnt += 1
        i = 0
    else:
        if i == len(croatiaAlphaSet)-1:
            flag = True
            cnt += len(s) - cnt # 남은 문자 - 공백 개수
        i += 1

print(cnt)      