using System.Collections.Generic;
using UnityEngine;

namespace TSG.Model
{
	public class LeaderboardModel : IListModel<LeaderboardEntryModel>
	{
		public int NumItems => entries.Count;

		public LeaderboardModel()
		{
			//mock data
			Random.InitState(123);

			for (int i = 0; i < 10000; ++i)
			{
				var r = Random.Range(0, NameList.Names.Length);
				var p = new LeaderboardEntryModel($"{NameList.Names[r]}{(i * 317) % 100}", Random.Range(0, 1000) * 50);
				entries.Add(p);
			}
		}

		public LeaderboardEntryModel GetItem(int index) => entries[index];

		public void AddItem(LeaderboardEntryModel model)
		{
			entries.Add(model);
		}

		private readonly List<LeaderboardEntryModel> entries = new List<LeaderboardEntryModel>();
	}
}