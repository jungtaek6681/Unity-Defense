using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildManager : SingleTon<BuildManager>
{
	[Header("Build")]
	[SerializeField]
	private Tower selectedTower;

	public Tower SelectedTower
	{
		get { return selectedTower; }
		private set { selectedTower = value; }
	}

	public void Build(TowerPlace place)
	{
		if (null == SelectedTower)
			return;

		Tower tower = Instantiate(selectedTower, place.transform.position, place.transform.rotation);
		place.tower = tower;
	}
}
