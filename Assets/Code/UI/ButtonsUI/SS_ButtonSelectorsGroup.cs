using System.Collections.Generic;
using UnityEngine;

public class SS_ButtonSelectorsGroup : MonoBehaviour
{
    protected List<SS_ButtonSelector> buttonSelectors = new List<SS_ButtonSelector>();
    protected SS_ButtonSelector currentButtonSelector = null;

    protected virtual void Awake()
    {
        GetComponentsInChildren(buttonSelectors);
    }

    protected virtual void Start()
    {
        for (int i = 0; i < buttonSelectors.Count; i++)
        {
            SS_ButtonSelector _buttonSelector = buttonSelectors[i];

            _buttonSelector.AddButtonOnClick(() =>
            {
                selectButtonSelector(_buttonSelector);
            });
        }
    }

    protected void selectButtonSelector(SS_ButtonSelector _buttonSelector)
    {
        currentButtonSelector?.Deselect();
        currentButtonSelector = _buttonSelector;
        currentButtonSelector?.Select();
    }
}
