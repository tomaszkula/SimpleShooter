using UnityEngine;

public class SS_BulletSelectorsGroup : SS_ButtonSelectorsGroup
{
    [Header("Events")]
    [SerializeField] SS_GameEvent onBulletChangeEvent = null;

    protected override void Start()
    {
        for (int i = 0; i < buttonSelectors.Count; i++)
        {
            SS_BulletSelector _bulletSelector = buttonSelectors[i] as SS_BulletSelector;

            _bulletSelector.AddButtonOnClick(() =>
            {
                changeBullet(_bulletSelector.BulletConfig);
            });
        }
    }

    public void OnBulletChange(SS_GameEventData _gameEventData)
    {
        SS_BulletConfig _bulletConfig = _gameEventData.ScriptableObjectValues[0] as SS_BulletConfig;
        SS_BulletSelector _bulletSelector = getBulletSelector(_bulletConfig);
        selectButtonSelector(_bulletSelector);
    }

    private void changeBullet(SS_BulletConfig _bulletConfig)
    {
        onBulletChangeEvent?.Invoke(new SS_GameEventData()
        {
            ScriptableObjectValues = new ScriptableObject[] { _bulletConfig }
        });
    }

    private SS_BulletSelector getBulletSelector(SS_BulletConfig _bulletConfig)
    {
        for (int i = 0; i < buttonSelectors.Count; i++)
        {
            SS_BulletSelector _bulletSelector = buttonSelectors[i] as SS_BulletSelector;
            if (_bulletSelector.BulletConfig == _bulletConfig)
            {
                return _bulletSelector;
            }
        }

        return null;
    }
}
