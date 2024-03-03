using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float arrowSpeed;

    private Monster target;
    private int damage;

    public void SetTarget(Monster monster)
    {
        this.target = monster;
        StartCoroutine(ArrowRoutine());
    }

    IEnumerator ArrowRoutine()
    {
        Vector3 startPoint = transform.position;
        Vector3 endPoint = target.transform.position;
        float time = Vector3.Distance(startPoint, endPoint) / arrowSpeed;

        float rate = 0f;
        while (rate < 1f)
        {
            if (target != null)
            {
                transform.LookAt(target.transform.position);
                endPoint = target.transform.position;
            }

            rate += Time.deltaTime / time;
            transform.position = Vector3.Lerp(startPoint, endPoint, rate);
            yield return null;
        }

        transform.position = endPoint;
        yield return null;

        if (target != null)
        {
            target.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
