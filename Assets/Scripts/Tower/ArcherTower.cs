using System.Collections;
using UnityEngine;

public class ArcherTower : Tower
{
    [SerializeField] Transform archer;
    [SerializeField] Transform arrowPoint;
    [SerializeField] Arrow arrowPrefab;

    [SerializeField] int attackDamage;
    [SerializeField] float attackDelay;

    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
        StartCoroutine(LookRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (targets.Count > 0)
            {
                Attack(targets[0]);
                yield return new WaitForSeconds(attackDelay);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator LookRoutine()
    {
        while (true)
        {
            if (targets.Count > 0)
            {
                Vector3 dir = (targets[0].transform.position - transform.position).normalized;
                archer.transform.rotation = Quaternion.Lerp(archer.transform.rotation, Quaternion.LookRotation(dir), 10f * Time.deltaTime);
            }

            yield return null;
        }
    }

    public void Attack(Monster monster)
    {
        Arrow arrow = Instantiate(arrowPrefab, arrowPoint.position, arrowPoint.rotation);
        arrow.SetTarget(monster);
        arrow.SetDamage(attackDamage);
    }
}
