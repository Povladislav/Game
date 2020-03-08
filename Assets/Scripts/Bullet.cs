using System;
using UnityEngine;

public enum bulletType
{
    Rock, Arrow, FireBall
};
public class Bullet : MonoBehaviour
{
    [SerializeField]
    int bulletDamage;
    [SerializeField]
    bulletType bullType;
    private Enemy target;

    public void SetTarget(Enemy enemy)
    {
        target = enemy;
    }
    private void MoveBullet()
    {
        var direction = target.transform.position - transform.position;
        var angleDirection = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleDirection, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 5 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Enemy>().GetDamage(bulletDamage);
        }
    }
    public int BulletGamage
    {
        get
        {
            return bulletDamage;
        }
    }
    public bulletType BullType
    {
        get
        {
            return bullType;
        }
    }
    private void Update()
    {
        MoveBullet();
    }

}
