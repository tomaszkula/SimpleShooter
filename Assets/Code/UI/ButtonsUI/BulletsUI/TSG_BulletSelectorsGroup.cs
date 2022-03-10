using UnityEngine;

public class TSG_BulletSelectorsGroup : TSG_ButtonSelectorsGroup
{
    [Header("Events")]
    [SerializeField] TSG_GameEvent onBulletChangeEvent = null;

    protected override void Start()
    {
        for (int i = 0; i < buttonSelectors.Count; i++)
        {
            TSG_BulletSelector _bulletSelector = buttonSelectors[i] as TSG_BulletSelector;

            _bulletSelector.AddButtonOnClick(() =>
            {
                changeBullet(_bulletSelector.BulletConfig);
            });
        }
    }

    public void OnBulletChange(TSG_GameEventData _gameEventData)
    {
        TSG_BulletConfig _bulletConfig = _gameEventData.ScriptableObjectValues[0] as TSG_BulletConfig;
        TSG_BulletSelector _bulletSelector = getBulletSelector(_bulletConfig);
        selectButtonSelector(_bulletSelector);
    }

    private void changeBullet(TSG_BulletConfig _bulletConfig)
    {
        onBulletChangeEvent?.Invoke(new TSG_GameEventData()
        {
            ScriptableObjectValues = new ScriptableObject[] { _bulletConfig }
        });
    }

    private TSG_BulletSelector getBulletSelector(TSG_BulletConfig _bulletConfig)
    {
        for (int i = 0; i < buttonSelectors.Count; i++)
        {
            TSG_BulletSelector _bulletSelector = buttonSelectors[i] as TSG_BulletSelector;
            if (_bulletSelector.BulletConfig == _bulletConfig)
            {
                return _bulletSelector;
            }
        }

        return null;
    }
}
