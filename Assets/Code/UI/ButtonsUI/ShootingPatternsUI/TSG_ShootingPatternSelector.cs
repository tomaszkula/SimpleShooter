using UnityEngine;

public class TSG_ShootingPatternSelector : TSG_ButtonSelector
{
    [Header("Properties")]
    [SerializeField] TSG_ShootingPattern shootingPattern = null;

    public TSG_ShootingPattern ShootingPattern => shootingPattern;
}
