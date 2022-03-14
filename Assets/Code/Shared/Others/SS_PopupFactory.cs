using System;
using System.Collections.Generic;
using UnityEngine;

public class SS_PopupFactory
{
	private readonly Dictionary<Type, SS_IPopup> instanceContainer;

	public SS_PopupFactory()
	{
		instanceContainer = new Dictionary<Type, SS_IPopup>();
	}

	public void RegisterInstance(SS_IPopup newInstance)
	{
		var type = newInstance.GetType();
		if (!instanceContainer.ContainsKey(type))
		{
			newInstance.Init();
			instanceContainer.Add(type, newInstance);
		}
		else
		{
			Debug.LogError(
				$"PopupFactory :: Trying to register instance of {newInstance.GetType()} that already exists.");
		}
	}

	public void UnregisterInstance(SS_IPopup newInstance)
	{
		var type = newInstance.GetType();
		if (instanceContainer.ContainsKey(type))
		{
			newInstance.Dispose();
			instanceContainer.Remove(type);
		}
	}

	public SS_IPopup GetInstance<T>()
	{
		var type = typeof(T);
		if (instanceContainer.TryGetValue(type, out var popup))
		{
			return popup;
		}

		return null;
	}

	public void Dispose()
	{
		foreach (var popup in instanceContainer.Values)
		{
			popup.Dispose();
		}
	}
}