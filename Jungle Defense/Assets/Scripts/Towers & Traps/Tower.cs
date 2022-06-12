using System;
using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform projectileLaunchPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private float projectileLaunchForce = 7f;
    private Animator _anim;
    private bool _canAtk = true;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Do nothing if the tower is on Cooldown
        if (!_canAtk) return;
        
        // Check for Enemy's Collider in the range: attackRange
        var enemyCheck = Physics2D.OverlapCircle(transform.position, attackRange, enemyLayerMask);
        
        // Attack the enemy (if it exists)
        if (enemyCheck) AttackPlayer(enemyCheck.transform.position);
    }

    private void AttackPlayer(Vector3 enemyPosition)
    {
        _canAtk = false;
        if (_anim) _anim.SetTrigger("Shoot");
        
        // Determine the angle to launch a projectile
        var dir = (enemyPosition - transform.position).normalized;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        RotateTower(angle);

        // Instantiate, rotate, and fire the projectile
        GameObject projectile = Instantiate(projectilePrefab, projectileLaunchPoint.position, Quaternion.identity);
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * projectileLaunchForce, ForceMode2D.Impulse);
        
        // Start the Attack Cooldown
        StartCoroutine(AtkCooldown());
    }
    
    // Waits for time: attackCooldown, then allows another attack.
    private IEnumerator AtkCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        _canAtk = true;
        yield return null;
    }

    protected virtual void RotateTower(float angleToRotate)
    {
        transform.rotation = Quaternion.AngleAxis(angleToRotate, Vector3.forward);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}