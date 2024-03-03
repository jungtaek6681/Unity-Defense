using System.Collections;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] LayerMask monsterMask;
    [SerializeField] float time;
    [SerializeField] float range;

    private Vector3 targetPos;
    private int damage;

    public void SetTargetPosition(Vector3 position)
    {
        targetPos = position;
        StartCoroutine(CanonRoutine());
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    IEnumerator CanonRoutine()
    {
        Vector3 startPoint = transform.position;
        Vector3 endPoint = targetPos;
        float xSpeed = (endPoint.x - startPoint.x) / time;
        float zSpeed = (endPoint.z - startPoint.z) / time;
        float ySpeed = -1 * (0.5f * Physics.gravity.y * time * time + startPoint.y) / time;

        float curTime = 0;
        while (curTime < time)
        {
            curTime += Time.deltaTime;

            transform.position += new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime;
            ySpeed += Physics.gravity.y * Time.deltaTime;

            yield return null;
        }

        transform.position = endPoint;
        yield return null;

        Explosion();
        Destroy(gameObject);
    }

    public void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, monsterMask);

        foreach (Collider collider in colliders)
        {
            Monster monster = collider.GetComponent<Monster>();
            monster?.TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
