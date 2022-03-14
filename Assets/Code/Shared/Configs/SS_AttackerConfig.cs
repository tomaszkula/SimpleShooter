using UnityEngine;

[CreateAssetMenu(fileName = "attackerConfig_NewAttackerConfig", menuName = "TSG/Configs/Attacker Config")]
public class SS_AttackerConfig : ScriptableObject
{
	public SS_DamageType DamageType = null;
	public float Damage = 0f;
}
