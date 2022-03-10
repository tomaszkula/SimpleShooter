using UnityEngine;

public class TSG_ShootingPatternSelectorsGroup : TSG_ButtonSelectorsGroup
{
    [Header("Events")]
    [SerializeField] TSG_GameEvent onShootingPatternChangeEvent = null;

    protected override void Start()
    {
        for (int i = 0; i < buttonSelectors.Count; i++)
        {
            TSG_ShootingPatternSelector _shootingPatternSelector = buttonSelectors[i] as TSG_ShootingPatternSelector;

            _shootingPatternSelector.AddButtonOnClick(() =>
            {
                changeShootingPattern(_shootingPatternSelector.ShootingPattern);
            });
        }
    }

    public void OnShootingPatternChange(TSG_GameEventData _gameEventData)
    {
        TSG_ShootingPattern _shootingPattern = _gameEventData.ScriptableObjectValues[0] as TSG_ShootingPattern;
        TSG_ShootingPatternSelector _shootingPatternSelector = getShootingPatternSelector(_shootingPattern);
        selectButtonSelector(_shootingPatternSelector);
    }

    private void changeShootingPattern(TSG_ShootingPattern _shootingPattern)
    {
        onShootingPatternChangeEvent?.Invoke(new TSG_GameEventData()
        {
            ScriptableObjectValues = new ScriptableObject[] { _shootingPattern }
        });
    }

    private TSG_ShootingPatternSelector getShootingPatternSelector(TSG_ShootingPattern _shootingPattern)
    {
        for (int i = 0; i < buttonSelectors.Count; i++)
        {
            TSG_ShootingPatternSelector _shootingPatternSelector = buttonSelectors[i] as TSG_ShootingPatternSelector;
            if (_shootingPatternSelector.ShootingPattern == _shootingPattern)
            {
                return _shootingPatternSelector;
            }
        }

        return null;
    }
}
