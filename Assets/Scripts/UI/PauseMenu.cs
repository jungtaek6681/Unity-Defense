using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	[SerializeField]
	private Button continueButton;
	[SerializeField]
	private Button restartButton;

	private void OnEnable()
	{
		GameManager.Instance.Pause();
	}

	private void OnDisable()
	{
		GameManager.Instance.Resume();
	}

	private void Start()
	{
		continueButton.onClick.AddListener(Continue);
		restartButton.onClick.AddListener(Restart);
	}

	public void Continue()
	{
		Destroy(gameObject);
	}

	public void Restart()
	{
		GameManager.Instance.LoadScene("GameScene");
	}
}
