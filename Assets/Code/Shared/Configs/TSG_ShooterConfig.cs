using UnityEngine;

[CreateAssetMenu(fileName = "shooterConfig_NewShooterConfig", menuName = "TSG/Configs/Shooter Config")]
public class TSG_ShooterConfig : ScriptableObject
{
    public TSG_BulletObjectsPool BulletObjectsPool = null;
    public TSG_MinMax Cooldown = new TSG_MinMax(0f, 0f);
}
