using UnityEngine;

public class SS_ShootingPatternSelectorsGroup : SS_ButtonSelectorsGroup
{
    [Header("Events")]
    [SerializeField] SS_GameEvent onShootingPatternChangeEvent = null;

    protected override void Start()
    {
        for (int i = 0; i < buttonSelectors.Count; i++)
        {
            SS_ShootingPatternSelector _shootingPatternSelector = buttonSelectors[i] as SS_ShootingPatternSelector;

            _shootingPatternSelector.AddButtonOnClick(() =>
            {
                changeShootingPattern(_shootingPatternSelector.ShootingPattern);
            });
        }
    }

    public void OnShootingPatternChange(SS_GameEventData _gameEventData)
    {
        SS_ShootingPattern _shootingPattern = _gameEventData.ScriptableObjectValues[0] as SS_ShootingPattern;
        SS_ShootingPatternSelector _shootingPatternSelector = getShootingPatternSelector(_shootingPattern);
        selectButtonSelector(_shootingPatternSelector);
    }

    private void changeShootingPattern(SS_ShootingPattern _shootingPattern)
    {
        onShootingPatternChangeEvent?.Invoke(new SS_GameEventData()
        {
            ScriptableObjectValues = new ScriptableObject[] { _shootingPattern }
        });
    }

    private SS_ShootingPatternSelector getShootingPatternSelector(SS_ShootingPattern _shootingPattern)
    {
        for (int i = 0; i < buttonSelectors.Count; i++)
        {
            SS_ShootingPatternSelector _shootingPatternSelector = buttonSelectors[i] as SS_ShootingPatternSelector;
            if (_shootingPatternSelector.ShootingPattern == _shootingPattern)
            {
                return _shootingPatternSelector;
            }
        }

        return null;
    }
}
