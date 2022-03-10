using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TSG_ButtonSelector : MonoBehaviour
{
    [Header("Selection")]
    [SerializeField] Image selectionImage = null;
    [SerializeField] Color selectedColor = new Color();
    [SerializeField] Color deselectedColor = new Color();

    [Header("Components")]
    protected Button myButton = null;

    protected virtual void Awake()
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
