#include <vector>
#include <cmath>

using namespace std;

vector<int> solution(vector<int> arr) {
    int n = arr.size();
    if (n == 0) return arr; 

    auto t = log2((double)n);

    auto ft = floor(t);
    const double eps = 1e-12;
    if (fabs(t - ft) < eps) {
        return arr; 
    }

    int size = pow(2.0, ft + 1.0); 
    arr.resize(size, 0);                
    return arr;
}

int main()
{
    auto answer = solution(
        {1,2,3,4,5,6}
    );
    return 0;
}