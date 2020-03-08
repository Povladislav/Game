using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenAttacks;
    [SerializeField]
    private float damageRadius;
    [SerializeField]
    Bullet bullet;

    private Enemy targetEnemy = null;
    private float attackCounter = 0;
    private bool isAttacking = false;




    private void Awake()
    {

    }
    private List<Enemy> GetEnemiesInRange()
    {
        List<Enemy> enemyList = new List<Enemy>();
        foreach (var enemy in GManager.instanse.enemyList)
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) <= damageRadius)
                enemyList.Add(enemy);
        }
        return enemyList;
    }

    public Enemy GetNearestEnemyInRange()
    {
        Enemy nearestEnemy = null;
        float smallestDistance = float.PositiveInfinity;
        foreach (var enemy in GetEnemiesInRange())
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) <= smallestDistance)
            {
                nearestEnemy = enemy;
                smallestDistance = Vector2.Distance(transform.position, enemy.transform.position);
            }
        }
        return nearestEnemy;
    }

    private void FocusEnemy()
    {
        targetEnemy = GetNearestEnemyInRange();
        if (targetEnemy != null)
            StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        if (isAttacking == false)
        {
            GameObject bull = Instantiate(bullet.gameObject, transform.position, transform.rotation);
            bull.GetComponent<Bullet>().SetTarget(targetEnemy);
            isAttacking = true;

            attackCounter = Time.fixedTime + timeBetweenAttacks;
        }

        yield return null;
    }
    private void Update()
    {
        FocusEnemy();
        if (isAttacking == true)
        {
            if (Time.fixedTime > attackCounter)
            {
                isAttacking = false;
            }
        }

    }
    //    private void Update()
    //    {
    //        attackCounter -= Time.deltaTime;
    //        if (targetEnemy == null)
    //        {
    //            Enemy nearestEnemy = GetNearestEnemy();
    //            if (Vector2.Distance(transform.position, nearestEnemy.transform.position) <= damageRadius)
    //            {
    //                targetEnemy = nearestEnemy;

    //            }
    //            if (attackCounter <= 0)
    //            {
    //                isAttacking = true;
    //                attackCounter = timeBetweenAttacks;
    //            }

    //            else
    //                isAttacking = false;
    //        }
    //        else
    //        {
    //            if (Vector2.Distance(transform.position, targetEnemy.transform.position) > damageRadius)
    //            {
    //                targetEnemy = null;
    //            }
    //        }
    //    }
    //    private void FixedUpdate()
    //    {
    //        if (isAttacking)
    //            Attack();
    //    }
    //    private void Attack()
    //    {
    //        attackCounter = timeBetweenAttacks;
    //        isAttacking = false;
    //        Bullet newBullet = Instantiate(bullet) as Bullet;
    //        if (targetEnemy == null)
    //        {
    //            Destroy(newBullet.gameObject);
    //        }
    //        else
    //        {
    //            StartCoroutine(MoveBullet(bullet));
    //        }
    //    }
    //    IEnumerator MoveBullet(Bullet bullet)
    //    {
    //        while (GetTargetDistance(targetEnemy) > 0.2f && targetEnemy != null && bullet != null)
    //        {
    //            var direction = transform.position - targetEnemy.transform.position;
    //            var angleDirection = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //            transform.rotation = Quaternion.AngleAxis(angleDirection, Vector3.forward);
    //            bullet.transform.position = Vector2.MoveTowards(bullet.transform.position, targetEnemy.transform.position, 5 * Time.deltaTime);
    //            yield return 0;

    //        }
    //        if (targetEnemy == null && bullet != null)
    //        {
    //            Destroy(bullet.gameObject);
    //        }
    //    }
    //    private float GetTargetDistance(Enemy targetEnemy)
    //    {
    //        if (targetEnemy == null)
    //        {
    //            targetEnemy = GetNearestEnemy();
    //            if (targetEnemy == null)
    //                return 0f;
    //        }
    //        return Mathf.Abs(Vector2.Distance(transform.localPosition, targetEnemy.transform.position));
    //    }
    //    private List<Enemy> GetEnemiesInRange()
    //    {
    //        List<Enemy> enemiesInRange = new List<Enemy>();
    //        foreach (var enemy in GManager.instanse.enemyList)
    //        {
    //            if (Vector2.Distance(transform.position, enemy.transform.position) <= damageRadius)
    //            {
    //                enemiesInRange.Add(enemy);
    //            }
    //        }
    //        return enemiesInRange;
    //    }
    //    private Enemy GetNearestEnemy()
    //    {
    //        Enemy nearestEnemy = null;
    //        float smallestDistance = float.PositiveInfinity;
    //        foreach (var enemy in GetEnemiesInRange())
    //        {
    //            if (Vector2.Distance(enemy.transform.position, transform.position) < smallestDistance)
    //            {
    //                nearestEnemy = enemy;
    //                smallestDistance = Vector2.Distance(enemy.transform.position, transform.position);
    //            }
    //        }
    //        return nearestEnemy;
    //    }

}
