#include <iostream>
#include <string>
#include <stack>
using namespace std;

int solution(string s)
{
    stack<char> stack;

    for (auto c : s)
    {
        if (!stack.empty() && c == stack.top()) stack.pop();
        else  stack.push(c);
    }

    return stack.empty();
}
