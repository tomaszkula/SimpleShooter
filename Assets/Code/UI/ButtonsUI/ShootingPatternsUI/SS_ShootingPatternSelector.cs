using UnityEngine;

public class SS_ShootingPatternSelector : SS_ButtonSelector
{
    [Header("Properties")]
    [SerializeField] SS_ShootingPattern shootingPattern = null;

    public SS_ShootingPattern ShootingPattern => shootingPattern;
}
