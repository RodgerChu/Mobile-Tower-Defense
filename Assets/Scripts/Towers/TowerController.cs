using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TowerController : MonoBehaviour
{
    public TowerStats towerStats;

    public GameObject weaponHead;
    public Transform projectileStartPosition;

    private float shootingTimer;
    private EnemyController targetEnemy;
    private List<EnemyController> enemiesInRange;

    void Start()
    {
        enemiesInRange = new List<EnemyController>();

        var shootRangeCollider = GetComponent<SphereCollider>();
        shootRangeCollider.radius = towerStats.fireRange;
    }

    void Update()
    {
        if (NeedReload())
        {
            ReloadWeapon();
        }

        if (targetEnemy != null)
        {
            TrackTargetEnemy();
            if (!NeedReload())
            {
                ShootTargetEnemy();
            }
        }
    }

    private void TrackTargetEnemy()
    {
        weaponHead.transform.LookAt(targetEnemy.transform);
    }

    private void ShootTargetEnemy()
    {
        var projectile = PoolManager.GetFromPool(towerStats.poolableProjectile);
        var bulletController = projectile.GetComponent<BulletController>();
        if (bulletController == null)
        {
            Debug.LogWarning("Projectile must contain bullet controller");
        }
        else
        {
            bulletController.damage = towerStats.damage;
            bulletController.FireAt(targetEnemy.transform.position, projectileStartPosition.position);
            shootingTimer = towerStats.fireSpeed;
        }
    }

    private bool NeedReload()
    {
        return shootingTimer != 0;
    }

    private void ReloadWeapon()
    {
        shootingTimer -= Time.deltaTime;
        if (shootingTimer < 0)
        {
            shootingTimer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var gObject = other.gameObject;
        var enemy = gObject.GetComponent<EnemyController>();
        if (enemy == null)
            return;

        if (targetEnemy == null)
        {
            targetEnemy = enemy;            
        }

        enemy.OnKill += OnTargetKill;
        enemiesInRange.Add(enemy);
    }

    private void OnTriggerExit(Collider other)
    {
        var gObject = other.gameObject;
        var enemy = gObject.GetComponent<EnemyController>();
        if (enemy == null)
            return;

        if (enemy == targetEnemy)
        {
            targetEnemy.OnKill -= OnTargetKill;
        }

        enemiesInRange.Remove(enemy);
        TargetNext();
    }

    private void OnTargetKill(EnemyController enemy)
    {
        enemy.OnKill -= OnTargetKill;
        enemiesInRange.Remove(enemy);
        if (targetEnemy == enemy)
        {
            TargetNext();
        }        
    }

    private void TargetNext()
    {
        if (enemiesInRange.Count != 0)
        {
            var newEnemy = enemiesInRange[0];
            targetEnemy = newEnemy;
        }
        else
        {
            targetEnemy = null;
        }
    }
}
