using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SS_Game : MonoBehaviour
{
    public static SS_Game Instance { get; private set; }

    private readonly Dictionary<Type, SS_IManager> managers = new Dictionary<Type, SS_IManager>();
    private readonly List<SS_IPopup> popups = new List<SS_IPopup>();

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        RegisterManager(new SS_PopupManager());

        GetComponentsInChildren(true, popups);
        for (int i = 0; i < popups.Count; i++)
        {
            var popup = popups[i];
            Get<SS_PopupManager>().RegisterPopup(popup);
        }
    }

    private void Start()
    {
        Get<SS_PopupManager>().Open<SS_SplashPopup>().Forget();
    }

    private void OnDestroy()
    {
        Get<SS_PopupManager>().Dispose();
    }

    public static T Get<T>() where T : SS_IManager
    {
        return (T) Instance.Get(typeof(T));
    }

    private SS_IManager Get(Type type)
    {
        return Instance.managers[type];
    }

    private void RegisterManager(SS_IManager manager)
    {
        var managerType = manager.GetType();

        void AddToDictionary(Dictionary<Type, SS_IManager> dict)
        {
            dict[managerType] = manager;
        }

        AddToDictionary(managers);
    }
}