#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

char** solution(const char* players[], size_t players_len, const char* callings[], size_t callings_len) {
    char** answer = (char**)malloc(sizeof(char*) * players_len);

    for (int i = 0; i < players_len; i++)
    {
        answer[i] = (char*)malloc(strlen(players[i]) + 1);
        strcpy(answer[i], players[i]);
    }


    for (int i = 0; i < callings_len; i++)
    {
        for (int a = 0; a < players_len; a++)
        {
            if (strcmp(callings[i], answer[a]))
                continue;

            char* tmp = (char*)malloc(strlen(answer[a - 1]) + 1);
            strcpy(tmp, answer[a - 1]);

            strcpy(answer[a - 1], answer[a]);
            strcpy(answer[a], tmp);
            break;
        }
    }


    return answer;
}