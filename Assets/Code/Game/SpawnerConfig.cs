using UnityEngine;

namespace TSG.Model
{
	[System.Serializable]
	public class SpawnerConfig
	{
		public GameObject Prefab;
		public float SpawnDelay;
		public Vector3 SpawnPosition;
	}
}