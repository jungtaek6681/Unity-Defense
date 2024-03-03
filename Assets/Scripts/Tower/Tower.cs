using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] AttackRange attackRange;

    public List<Monster> targets => attackRange.monsters;
}
