#include <iostream>
#include <map>

#define endl '\n'
using namespace std;

int n;
int m;
map<int, bool> mp;

int main()
{
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	cin >> n;
	for (int i = 0; i < n; i++)
	{
		int A;
		cin >> A;

		mp[A]++;
	}

	cin >> m;

	for (int i = 0; i < m; i++)
	{
		int A;
		cin >> A;
		if (mp[A])
		{
			cout << "1 ";
		}
		else
		{
			cout << "0 ";
		}
	}

}