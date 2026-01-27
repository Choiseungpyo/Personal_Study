#include <string>
#include <vector>
#include <unordered_map>

using namespace std;

int add(unsigned a, unsigned b) { return a + b; }
int sub(unsigned a, unsigned b) { return a - b; }
int mul(unsigned a, unsigned b) { return a * b; }

int solution(string binomial) {
    unordered_map<char, int(*)(unsigned, unsigned)> operators;

    operators['+'] = add;
    operators['-'] = sub;
    operators['*'] = mul;

    for (auto op : operators)
    {
        auto pos = binomial.find(op.first);

        if (pos != string::npos)
        {
            int a = stoi(binomial.substr(0, pos));
            int b = stoi(binomial.substr(pos + 1));
            return op.second(a, b);
        }
    }

    return -1;
}
