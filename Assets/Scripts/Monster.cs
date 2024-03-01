using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    private Transform[] wayPoints;
    private int curIndex;

    private void Start()
    {
        curIndex = 0;
        agent.destination = wayPoints[curIndex].position;
        moveRoutine = StartCoroutine(MoveRoutine());
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
