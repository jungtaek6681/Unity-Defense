using System.Collections;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float hintRange;

    private Monster target;
    private int damage;

    public void SetTarget(Monster monster)
    {
        this.target = monster;
        StartCoroutine(MagicRoutine());
    }

    IEnumerator MagicRoutine()
    {
        Vector3 startPoint = transform.position;
        Vector3 endPoint = target.transform.position;
        Vector3 circle = Random.insideUnitCircle.normalized;
        Vector3 hintPoint = startPoint + new Vector3(circle.x * hintRange, hintRange, circle.y * hintRange);

        float time = Vector3.Distance(startPoint, endPoint) / speed;

        float rate = 0f;
        while (rate < 1f)
        {
            if (target != null)
            {
                endPoint = target.transform.position;
            }

            rate += Time.deltaTime / time;
            Vector3 AB = Vector3.Lerp(startPoint, hintPoint, rate);
            Vector3 BC = Vector3.Lerp(hintPoint, endPoint, rate);
            transform.position = Vector3.Lerp(AB, BC, rate);
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
