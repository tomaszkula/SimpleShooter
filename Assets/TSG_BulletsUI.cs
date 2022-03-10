using System.Collections.Generic;
using UnityEngine;

public class TSG_BulletsUI : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TSG_GameEvent onBulletSelectEvent = null;

    List<TSG_BulletSelectorButton> bulletSelectorButtons = new List<TSG_BulletSelectorButton>();
    TSG_BulletSelectorButton currentSelectedButton = null;

    private void Awake()
    {
        GetComponentsInChildren(bulletSelectorButtons);
    }

    private void Start()
    {
        for (int i = 0; i < bulletSelectorButtons.Count; i++)
        {
            TSG_BulletSelectorButton _bulletSelectorButton = bulletSelectorButtons[i];

            _bulletSelectorButton.AddButtonOnClick(() =>
            {
                selectBullet(_bulletSelectorButton.BulletConfig);
                selectBulletSelectorButton(_bulletSelectorButton);
            });
        }
    }

    public void OnBulletSellect(TSG_GameEventData _gameEventData)
    {
        TSG_BulletConfig _bulletConfig = _gameEventData.ScriptableObjectValues[0] as TSG_BulletConfig;
        TSG_BulletSelectorButton _bulletSelectorButton = getBulletSelectorButton(_bulletConfig);
        selectBulletSelectorButton(_bulletSelectorButton);
    }

    private void selectBullet(TSG_BulletConfig _bulletConfig)
    {
        onBulletSelectEvent?.Invoke(new TSG_GameEventData()
        {
            ScriptableObjectValues = new ScriptableObject[] { _bulletConfig }
        });
    }

    private void selectBulletSelectorButton(TSG_BulletSelectorButton _bulletSelectorButton)
    {
        currentSelectedButton?.Deselect();
        currentSelectedButton = _bulletSelectorButton;
        currentSelectedButton?.Select();
    }

    private TSG_BulletSelectorButton getBulletSelectorButton(TSG_BulletConfig _bulletConfig)
    {
        for (int i = 0; i < bulletSelectorButtons.Count; i++)
        {
            if(bulletSelectorButtons[i].BulletConfig == _bulletConfig)
            {
                return bulletSelectorButtons[i];
            }
        }

        return null;
    }
}
