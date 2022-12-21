using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerElementUI : MonoBehaviour
{
	private Tower tower;

	[SerializeField]
	private Button button;
	[SerializeField]
	private Image buttonImage;
	[SerializeField]
	private TextMeshProUGUI cost;

	private void Start()
	{
		BuildManager.Instance.OnChangeEnergy += Refresh;

		Refresh(BuildManager.Instance.Energy);
		button.onClick.AddListener(Clicked);
	}

	public void SetTower(Tower tower)
	{
		this.tower = tower;
		buttonImage.sprite = tower.icon;
		cost.text = tower.Cost.ToString();
	}

	public void Clicked()
	{
		BuildManager.Instance.ChangeSelectedTower(tower);
	}

	public void Refresh(int energy)
	{
		if (energy >= tower.Cost)
			button.interactable = true;
		else
			button.interactable = false;
	}
}
