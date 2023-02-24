using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baton : MonoBehaviour
{
    public int damage = 30;
    public float knockbackStrength = 100f;
    public float staggerDuration = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject target = collision.gameObject;
        MeleeHit(target, damage, knockbackStrength,staggerDuration);
    }

    private void MeleeHit(GameObject target, int damage, float knockbackStrength, float staggerDuration)
    {
        target.GetComponent<EnemyHealth>().TakeDamage(damage);

        Vector2 knockbackDirection = (target.transform.position - transform.position).normalized;

        Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();
        targetRb.AddForce(knockbackDirection * knockbackStrength, ForceMode2D.Impulse);

        StartCoroutine(StaggerCoroutine(target, staggerDuration));
    }
    private IEnumerator StaggerCoroutine(GameObject target, float duration)
    {
        target.GetComponent<EnemyMovement>().enabled = false;

        yield return new WaitForSeconds(duration);

        target.GetComponent<EnemyMovement>().enabled = true;
    }

}
