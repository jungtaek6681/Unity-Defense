using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public List<Monster> monsters = new List<Monster>();
    public LayerMask monsterMask;

    private void OnTriggerEnter(Collider other)
    {
        if (monsterMask.Contain(other.gameObject.layer))
        {
            Monster monster = other.GetComponent<Monster>();
            monster.OnDied += RemoveMonsterList;
            monsters.Add(monster);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (monsterMask.Contain(other.gameObject.layer))
        {
            Monster monster = other.GetComponent<Monster>();
            monster.OnDied -= RemoveMonsterList;
            monsters.Remove(monster);
        }
    }

    private void RemoveMonsterList(Monster monster)
    {
        monsters.Remove(monster);
    }
}
