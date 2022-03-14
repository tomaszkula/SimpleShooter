using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SS_SplashPopup : SS_PopupState<SS_SplashPopup>
{
	[Header("References")]
	[SerializeField] Button playButton = null;
	[SerializeField] TMP_InputField nicknameInputField = null;

	public override void Init()
	{
		base.Init();
		playButton.onClick.AddListener(OnPlayButtonClicked);
	}

	private void OnPlayButtonClicked()
	{
		saveNickname();

		SceneManager.LoadScene(1);
		Close();
	}

	public override void Dispose()
	{
		base.Dispose();
		playButton.onClick.RemoveListener(OnPlayButtonClicked);
	}

	private void saveNickname()
	{
		string _nickname = nicknameInputField.text;
		_nickname = _nickname?.Trim();
		if (string.IsNullOrEmpty(_nickname))
		{
			_nickname = SS_Nickname.DEFAULT_NICKNAME;
		}

		SS_Nickname.Nickname = _nickname;
	}
}