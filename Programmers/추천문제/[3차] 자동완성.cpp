#include <iostream>
#include <vector>
#include <string>
using namespace std;

struct TrieNode {
    TrieNode* children[26];
    int childCount;   // 자식 노드 수
    bool isEnd;       // 단어 끝 표시

    TrieNode() : childCount(0), isEnd(false) {
        for (int i = 0; i < 26; i++) children[i] = nullptr;
    }
};

class Trie {
private:
    TrieNode* root;
public:
    Trie() {
        root = new TrieNode();
    }

    void insert(const string& word) {
        TrieNode* curr = root;
        for (char c : word) {
            int idx = c - 'a';
            if (curr->children[idx] == nullptr) {
                curr->children[idx] = new TrieNode();
                curr->childCount++;
            }
            curr = curr->children[idx];
        }
        curr->isEnd = true;
    }

    int countTyping(const string& word) {
        TrieNode* curr = root;
        int cnt = 0;
        for (int i = 0; i < (int)word.size(); i++) {
            int idx = word[i] - 'a';
            curr = curr->children[idx];
            cnt++;
            if (curr->childCount > 1 || curr->isEnd)
                break;
        }
        return cnt;
    }
};

int solution(vector<string> words) {
    Trie trie;
    for (const string& w : words)
        trie.insert(w);
   
    int answer = 0;
    for (const string& w : words)
        answer += trie.countTyping(w);
    
    return answer;
}