using UnityEngine;

public class TSG_BulletSelector : TSG_ButtonSelector
{
    [Header("Properties")]
    [SerializeField] TSG_BulletConfig bulletConfig = null;

    public TSG_BulletConfig BulletConfig => bulletConfig;
}
