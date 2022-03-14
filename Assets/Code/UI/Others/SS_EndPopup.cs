using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SS_EndPopup : MonoBehaviour
{
	[Header("References")]
	[SerializeField] GameObject mainView = null;
	[SerializeField] Button playButton = null;

	private void Awake()
	{
		playButton.onClick.AddListener(onPlayButtonClicked);
	}

	public void OnLevelFail()
	{
		show();
	}

	private void onPlayButtonClicked()
	{
		SceneManager.LoadScene(1);
		hide();
	}

	private void show()
	{
		mainView.SetActive(true);
	}

	private void hide()
	{
		mainView.SetActive(false);
	}
}