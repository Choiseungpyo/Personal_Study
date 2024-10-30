while True:
    nums = list(map(int, input().split(' ')))
    if nums[0] == 0 and nums[1] == 0:
        break
    
    result = ""
    if nums[1] % nums[0] == 0:
        result = "factor"
    elif nums[0] % nums[1] == 0:
        result = "multiple"
    else:
        result = "neither"
    print(result)