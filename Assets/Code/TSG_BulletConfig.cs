using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bulletConfig_NewBulletConfig", menuName = "TSG/Bullet Config")]
public class TSG_BulletConfig : ScriptableObject
{
	public TSG_DamageType DamageType = null;
	public float Damage = 0f;
	public float MoveSpeed = 0f;
	//public float BulletCooldown;
}
