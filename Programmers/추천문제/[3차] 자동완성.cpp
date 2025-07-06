#include <iostream>
#include <vector>
#include <string>
using namespace std;

struct TrieNode {
    TrieNode* children[26];
    int count;

    TrieNode() : count(0) {
        for (int i = 0; i < 26; i++)
            children[i] = nullptr;
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
            if (curr->children[idx] == nullptr)
                curr->children[idx] = new TrieNode();

            curr = curr->children[idx];
            curr->count++;
        }
    }

    int countTyping(const string& word) {
        TrieNode* curr = root;
        int cnt = 0;
        for (char c : word) {
            int idx = c - 'a';
            curr = curr->children[idx];
            cnt++;
            if (curr->count == 1)
                break;
        }
        return cnt;
    }
};

int solution(vector<string> words) {
    Trie trie;
    for (const string& word : words)
        trie.insert(word);

    int total = 0;
    for (const string& word : words)
        total += trie.countTyping(word);
    return total;
}