using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotController : BulletController
{
    public LineRenderer lineRenderer;    

    public override void FireAt(EnemyController target, Transform startPosition)
    {
        StopAllCoroutines();
        HideLine();

        lineRenderer.positionCount = 2;

        var startPoint = startPosition.position;
        var targetPoint = target.transform.position;
        var points = new Vector3[2];
        points[0] = startPoint;
        points[1] = targetPoint;        

        lineRenderer.SetPositions(points);
        Debug.Log("Give damage: " + damage);
        target.TakeDamage(damage);

        StartCoroutine(HideLaser());
    }

    public override void OnMovedToPool()
    {
        HideLine();
    }

    private IEnumerator HideLaser()
    {
        yield return new WaitForSeconds(0.1f);
        HideLine();
    }

    private void HideLine()
    {
        lineRenderer.SetPositions(new Vector3[0]);
        lineRenderer.positionCount = 0;
    }
}
