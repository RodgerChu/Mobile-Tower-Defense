using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : Poolable
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        var gObject = other.gameObject;
        var enemyController = gObject.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.enemyStats.TakeDamage(damage);
            MoveToPool();
            return;
        }

        var tag = gObject.tag;
        if (tag == "Flour" || tag == "Road")
        {
            MoveToPool();
        }
    }

    public override void OnActivatedFromPool()
    {
        StartCoroutine(DeactivateCorutine());
    }

    public override void OnMovedToPool()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    public void FireAt(Vector3 target, Vector3 startPosition)
    {
        transform.position = startPosition;
        transform.LookAt(target);

        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            Debug.LogWarning("Projectile must contain rigidbody component");
        }
        else
        {
            rigidbody.AddForce(transform.forward * 600, ForceMode.Acceleration);
        }
    }

    private void MoveToPool()
    {
        StopAllCoroutines();
        PoolManager.AddToPool(this);
    }

    private IEnumerator DeactivateCorutine()
    {
        float elapsedTime = 0;
        while (elapsedTime < 10f)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
        }

        MoveToPool();
    }
}
