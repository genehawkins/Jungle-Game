using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform Point;
    public GameObject ProjectilePreFab;
    bool alreadyAttacked;
    public float timeBetweenAttacks;
    public float attackRange;
    public LayerMask EnemyLayer;
    private Collider2D EnemyCheck;


    void Start()
    {
        //Debug.Log(!alreadyAttacked);
    }

    void Update()
    {
        EnemyCheck = Physics2D.OverlapCircle(transform.position, attackRange, EnemyLayer);
        if (EnemyCheck != null)
        {
            AttackPlayer(EnemyCheck.GetComponent<Transform>());
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void AttackPlayer(Transform enemy)
    {
        if (alreadyAttacked == false)
        {
            Vector3 dir = enemy.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Creates projectile
            GameObject NewProjectile = Instantiate(ProjectilePreFab, Point.position, Quaternion.identity);
            NewProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            NewProjectile.GetComponent<Rigidbody2D>().AddForce(dir * 400);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
}
