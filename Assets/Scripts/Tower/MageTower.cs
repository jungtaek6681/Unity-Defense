using System.Collections;
using UnityEngine;

public class MageTower : Tower
{
    [SerializeField] MagicBall magicPrefab;
    [SerializeField] Transform crystalPoint;
    [SerializeField] float rotateSpeed;

    [SerializeField] int attackDamage;
    [SerializeField] float attackDelay;

    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
        StartCoroutine(RotateRoutine());
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

    IEnumerator RotateRoutine()
    {
        while (true)
        {
            crystalPoint.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void Attack(Monster monster)
    {
        MagicBall magic = Instantiate(magicPrefab, crystalPoint.position, crystalPoint.rotation);
        magic.SetTarget(monster);
        magic.SetDamage(attackDamage);
    }
}
