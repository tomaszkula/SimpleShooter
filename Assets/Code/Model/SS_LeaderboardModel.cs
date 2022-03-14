using System.Collections.Generic;
using UnityEngine;

public class SS_LeaderboardModel : SS_IListModel<SS_LeaderboardEntryModel>
{
	public int NumItems => entries.Count;

	public SS_LeaderboardModel()
	{
		//mock data
		Random.InitState(123);

		for (int i = 0; i < 10000; ++i)
		{
			var r = Random.Range(0, SS_NameList.Names.Length);
			var p = new SS_LeaderboardEntryModel($"{SS_NameList.Names[r]}{(i * 317) % 100}", Random.Range(0, 1000) * 50);
			entries.Add(p);
		}
	}

	public SS_LeaderboardEntryModel GetItem(int index) => entries[index];

	public void AddItem(SS_LeaderboardEntryModel model)
	{
		entries.Add(model);
	}

	public void Sort()
	{
		entries.Sort();
	}

	public int IndexOf(SS_LeaderboardEntryModel _leaderboardEntryModel)
    {
		return entries.IndexOf(_leaderboardEntryModel);
    }

	private readonly List<SS_LeaderboardEntryModel> entries = new List<SS_LeaderboardEntryModel>();
}