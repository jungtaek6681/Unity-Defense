using System.Collections;
using UnityEngine;

public class CannonTower : Tower
{
    [SerializeField] CannonBall cannonBall;
    [SerializeField] Transform cannonPoint;

    [SerializeField] int attackDamage;
    [SerializeField] float attackDelay;

    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
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
                Attack(targets[0].transform.position);
                yield return new WaitForSeconds(attackDelay);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void Attack(Vector3 position)
    {
        CannonBall canonBall = Instantiate(cannonBall, cannonPoint.position, Quaternion.identity);
        canonBall.SetTargetPosition(position);
        canonBall.SetDamage(attackDamage);
    }
}
