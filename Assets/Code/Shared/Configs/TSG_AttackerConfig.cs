using UnityEngine;

[CreateAssetMenu(fileName = "attackerConfig_NewAttackerConfig", menuName = "TSG/Configs/Attacker Config")]
public class TSG_AttackerConfig : ScriptableObject
{
	public TSG_DamageType DamageType = null;
	public float Damage = 0f;
}
