using UnityEngine;

[CreateAssetMenu(fileName = "bulletConfig_NewBulletConfig", menuName = "TSG/Configs/Bullet Config")]
public class TSG_BulletConfig : ScriptableObject
{
    public TSG_BulletObjectsPool BulletObjectsPool = null;
    public TSG_MinMax Cooldown = new TSG_MinMax(0f, 0f);
}
