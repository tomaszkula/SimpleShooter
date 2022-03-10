using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TSG_BulletSelectorButton : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] TSG_BulletConfig bulletConfig = null;

    public TSG_BulletConfig BulletConfig => bulletConfig;

    [Header("Selection")]
    [SerializeField] Image selectionImage = null;
    [SerializeField] Color selectedColor = new Color();
    [SerializeField] Color deselectedColor = new Color();

    [Header("Components")]
    Button myButton = null;

    private void Awake()
    {
        myButton = GetComponent<Button>();
    }

    public void AddButtonOnClick(Action _onClick)
    {
        myButton.onClick.AddListener(() => _onClick());
    }

    public void Select()
    {
        selectionImage.color = selectedColor;
    }

    public void Deselect()
    {
        selectionImage.color = deselectedColor;
    }
}
