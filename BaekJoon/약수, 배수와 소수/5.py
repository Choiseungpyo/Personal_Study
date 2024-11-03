while True:
    n = int(input())
    if n == -1:
        break
    sum = 0
    nums = []
    for i in range(1, n):
        if n%i == 0:
            sum += i
            nums.append(i)  
    if n == sum:
        print(f"{n} = " + " + ".join(str(i) for i in nums))
    else:
        print(f"{n} is NOT perfect.")