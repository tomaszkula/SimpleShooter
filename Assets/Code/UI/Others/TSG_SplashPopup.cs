using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace TSG.Popups
{
	public class TSG_SplashPopup : PopupState<TSG_SplashPopup>
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
				_nickname = TSG_Nickname.DEFAULT_NICKNAME;
			}

			TSG_Nickname.Nickname = _nickname;
		}
	}
}