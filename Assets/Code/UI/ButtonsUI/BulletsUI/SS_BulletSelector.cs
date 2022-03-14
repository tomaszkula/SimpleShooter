using UnityEngine;

public class SS_BulletSelector : SS_ButtonSelector
{
    [Header("Properties")]
    [SerializeField] SS_BulletConfig bulletConfig = null;

    public SS_BulletConfig BulletConfig => bulletConfig;
}
