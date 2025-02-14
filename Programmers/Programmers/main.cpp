#include <string>
#include <vector>

using namespace std;

int solution(string t, string p) {
    int answer = 0;
    for (int i = 0; i < t.length()-p.length()+1; i++)
    {
        if (stoi(t.substr(i, p.length())) <= stoi(p))
            answer++;
    }
    return answer;
}


int main(void) 
{
    vector<int> arr = { 4,4,4,3,3,1 };
    auto result = solution("3141592", "271");

    return 0;
}