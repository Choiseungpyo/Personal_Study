#include <string>
#include <vector>

using namespace std;

int gcd(int a, int b) {
    int tmp;
    while (b != 0)
    {
        tmp = a % b;
        a = b;
        b = tmp;
    }
    return a;
}

int lcm(int a, int b)
{
    return (a * b) / gcd(a, b);
}

vector<int> solution(int n, int m) {
    return { gcd(n,m), lcm(n,m) };
}
