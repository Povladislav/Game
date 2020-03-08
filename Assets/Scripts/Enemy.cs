using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int target = 0;
    [SerializeField]
    private int health;
    [SerializeField]
    private Transform exitPoint;
    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private float navigationUpdate;
    [SerializeField]
    private Animator animator;

    private Transform enemy;
    private float navigationTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<Transform>();
        GManager.instanse.RegisterEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        if (wayPoints != null)
        {
            navigationTime += Time.deltaTime;
            if (navigationTime > navigationUpdate)
            {
                if (target < wayPoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, navigationTime);
                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigationTime);
                }
                navigationTime = 0;
            }
        }
    }
    private void OnDestroy()
    {
        GManager.instanse.UnRegisterEnemy(this);
    }
    public int GetDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hit");
        return health;
    }
    private void CheckHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            target += 1;
        }
        else if (collision.CompareTag("Finish"))
        {
            Destroy(gameObject);
            GManager.instanse.UnRegisterEnemy(this);
        }
    }
}
