using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SS_PopupManager : SS_IManager
{
	private List<SS_IPopup> openedPopups;
	private SS_PopupFactory factory;

	public SS_PopupManager()
	{
		factory = new SS_PopupFactory();
		openedPopups = new List<SS_IPopup>();
	}

	public void RegisterPopup(SS_IPopup popup)
	{
		factory.RegisterInstance(popup);
	}

	public void UnregisterPopup(SS_IPopup popup)
	{
		factory.UnregisterInstance(popup);
	}

	public void Dispose()
	{
		factory?.Dispose();
		factory = null;
		openedPopups = null;
	}

	public T Get<T>()
	{
		return (T) factory.GetInstance<T>();
	}

	public bool IsOpenOnTop<T>()
	{
		var instance = factory.GetInstance<T>();
		return openedPopups.Last() == instance;
	}

	public bool IsOpen<T>()
	{
		var instance = factory.GetInstance<T>();
		return openedPopups.Contains(instance);
	}

	public async UniTask Open<T>(Action<bool> onComplete = null)
	{
		var popupToOpen = factory.GetInstance<T>();
		if (popupToOpen == null)
		{
			Debug.LogError($"Trying to open a popup that does not exist - {typeof(T)}");
			onComplete?.Invoke(false);
			return;
		}

		var returnTask = await OpenInternal<T>(popupToOpen);
		if (!popupToOpen.Equals(null))
		{
			onComplete?.Invoke(returnTask);
		}
	}

	public void Close<T>()
	{
		var popupToClose = factory.GetInstance<T>();
		if (popupToClose == null)
		{
			Debug.LogError($"Trying to close a popup that does not exist - {typeof(T)}");
			return;
		}

		if (openedPopups != null && openedPopups.Contains(popupToClose))
		{
			popupToClose.Close();
		}
	}

	private async UniTask<bool> OpenInternal<T>(SS_IPopup popupToOpen)
	{
		if (IsOpen<T>())
		{
			Debug.Log($"Popup already opened - {typeof(T)}");
			return false;
		}

		openedPopups.Add(popupToOpen);
		var openTask = await popupToOpen.Open();
		openedPopups.Remove(popupToOpen);

		return openTask;
	}
}