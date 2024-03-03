using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Data/Tower")]
public class TowerData : ScriptableObject
{
    public new string name;
    [TextArea(3, 5)]
    public string description;
    public Tower prefab;
    public TowerInfo[] levels;

    [Serializable]
    public class TowerInfo
    {
        public float buildTime;
        public float buildCost;
        public float sellCost;
    }
}
