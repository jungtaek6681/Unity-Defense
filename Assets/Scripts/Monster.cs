using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] int hp;
    public int HP { get { return hp; } private set { hp = value; } }

    public event UnityAction<Monster> OnDied;


    private Transform[] wayPoints;
    private int curIndex;

    private void Start()
    {
        curIndex = 0;
        agent.destination = wayPoints[curIndex].position;
        moveRoutine = StartCoroutine(MoveRoutine());
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDied?.Invoke(this);
        Destroy(gameObject);
    }

    public void SetWayPoints(Transform[] wayPoints)
    {
        this.wayPoints = wayPoints;
    }

    Coroutine moveRoutine;
    IEnumerator MoveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if ((wayPoints[curIndex].position - transform.position).sqrMagnitude < 0.1f)
            {
                if (++curIndex < wayPoints.Length)
                {
                    agent.destination = wayPoints[curIndex].position;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
