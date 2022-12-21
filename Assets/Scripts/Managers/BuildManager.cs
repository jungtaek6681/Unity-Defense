using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildManager : SingleTon<BuildManager>
{
	[Header("Build")]
	private Tower selectedTower;
	[SerializeField]
	private int energy;

	public UnityAction<int> OnChangeEnergy;

	public Tower SelectedTower
	{
		get { return selectedTower; }
		private set { selectedTower = value; }
	}

	public int Energy
	{
		get { return energy; }
		private set { energy = value; OnChangeEnergy?.Invoke(energy); }
	}

	public void Build(TowerPlace place)
	{
		if (null == SelectedTower)
			return;

		if (Energy < SelectedTower.Cost)
			return;

		Tower tower = Instantiate(selectedTower, place.transform.position, place.transform.rotation);
		place.tower = tower;
		Energy -= tower.Cost;
	}

	public void ChangeSelectedTower(Tower tower)
	{
		SelectedTower = tower;
	}

	public void GainEnergy(int energy)
	{
		Energy += energy;
	}
}
