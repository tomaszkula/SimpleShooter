using System.Collections.Generic;
using UnityEngine;

public class TSG_ButtonSelectorsGroup : MonoBehaviour
{
    protected List<TSG_ButtonSelector> buttonSelectors = new List<TSG_ButtonSelector>();
    protected TSG_ButtonSelector currentButtonSelector = null;

    protected virtual void Awake()
    {
        GetComponentsInChildren(buttonSelectors);
    }

    protected virtual void Start()
    {
        for (int i = 0; i < buttonSelectors.Count; i++)
        {
            TSG_ButtonSelector _buttonSelector = buttonSelectors[i];

            _buttonSelector.AddButtonOnClick(() =>
            {
                selectButtonSelector(_buttonSelector);
            });
        }
    }

    protected void selectButtonSelector(TSG_ButtonSelector _buttonSelector)
    {
        currentButtonSelector?.Deselect();
        currentButtonSelector = _buttonSelector;
        currentButtonSelector?.Select();
    }
}
