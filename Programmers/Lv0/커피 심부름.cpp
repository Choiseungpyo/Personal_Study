#include <string>
#include <vector>
#include <unordered_map>

using namespace std;

int solution(vector<string> order) {
    int answer = 0;
    unordered_map<string, int> map{
        {"americano", 4500},
        {"cafelatte", 5000 },
        {"anything" , 4500}
    };

    for (const auto& o : order) {
        for (const auto& kv : map) {
            auto it = o.find(kv.first);
            if (it != string::npos) {
                answer += kv.second;
                break;
            }
        }
    }

    return answer;
}