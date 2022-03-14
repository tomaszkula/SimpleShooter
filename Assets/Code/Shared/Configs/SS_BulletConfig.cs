using UnityEngine;

[CreateAssetMenu(fileName = "bulletConfig_NewBulletConfig", menuName = "TSG/Configs/Bullet Config")]
public class SS_BulletConfig : ScriptableObject
{
    public SS_ObjectsPool BulletObjectsPool = null;
    public SS_MinMax Cooldown = new SS_MinMax(0f, 0f);
}
