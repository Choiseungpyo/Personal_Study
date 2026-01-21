#include <string>
#include <vector>
#include <algorithm>
using namespace std;

int solution(vector<vector<int>> sizes) {
    vector<int> minSizes;
    int maxSize = 0;

    for (const auto& size : sizes)
    {
        int width = size[0];
        int height = size[1];

        minSizes.push_back(width > height ? height : width);

        if (width > maxSize)
            maxSize = width;

        if (height > maxSize)
            maxSize = height;
    }

    sort(minSizes.begin(), minSizes.end(), greater<int>());

    return minSizes[0] * maxSize;
}