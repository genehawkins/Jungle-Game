using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelTurrent : MonoBehaviour

{
    private Transform target;

    [Header("Attributes")] //Things that can be upgraded 
    public float range = 15f;
    //For firing out of turrents 
    public float fireRate = 2f;
    private float fireCount = 0f;


    [Header("Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject BulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);   
    }

    void UpdateTarget (){

        GameObject[] enemines = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemines){

            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance){

                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

            }

            if(nearestEnemy != null && shortestDistance <= range){

                target = nearestEnemy.transform;
            }
            else{

                target = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            return;
        }

        //Target Lock-On
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        if (fireCount <= 0f){

            Shoot();
            fireCount = 1f / fireRate;
        }

        fireCount -= Time.deltaTime; //This will make sure that every fireCount will be reduce by 1

    }

    void Shoot(){

        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnDrawGizmosSelected (){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
