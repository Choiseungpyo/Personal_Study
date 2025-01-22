data = list(map(int, input().split()))
cMajorData = [1,2,3,4,5,6,7,8]
result = "mixed"
if data == cMajorData:
    result = "ascending"
else: 
    data.reverse()
    if data == cMajorData:
        result = "descending"
print(result)