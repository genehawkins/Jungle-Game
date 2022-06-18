using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHiveTower : MonoBehaviour
{
    [SerializeField] private float projectileLaunchForce = 2f;
    [SerializeField] private float cooldownTime = 0.5f;
    
    // lol this is pretty ridiculous :)
    [Header("Bee Prefabs")]
    [SerializeField] private GameObject beeNW; 
    [SerializeField] private GameObject beeN; 
    [SerializeField] private GameObject beeNE; 
    [SerializeField] private GameObject beeE; 
    [SerializeField] private GameObject beeSE; 
    [SerializeField] private GameObject beeS; 
    [SerializeField] private GameObject beeSW; 
    [SerializeField] private GameObject beeW;

    private bool canShoot = true;

    private void Update()
    {
        FireBees();
    }

    private void FireBees()
    {
        if (!canShoot) return;
        canShoot = false;
        
        Vector3 dir;
        GameObject projectile;
        
        // NW:
        dir = new Vector3(-0.1f, 0.1f);
        projectile = Instantiate(beeNW, transform.position + dir, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * projectileLaunchForce, ForceMode2D.Impulse);
        
        // N
        dir = new Vector3(0f, 0.1f);
        projectile = Instantiate(beeN, transform.position + dir, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * projectileLaunchForce, ForceMode2D.Impulse);
        
        // NE
        dir = new Vector3(0.1f, 0.1f);
        projectile = Instantiate(beeNE, transform.position + dir, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * projectileLaunchForce, ForceMode2D.Impulse);
        
        // E
        dir = new Vector3(0.1f, 0f);
        projectile = Instantiate(beeE, transform.position + dir, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * projectileLaunchForce, ForceMode2D.Impulse);
        
        // SE
        dir = new Vector3(0.1f, -0.1f);
        projectile = Instantiate(beeSE, transform.position + dir, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * projectileLaunchForce, ForceMode2D.Impulse);
        
        // S
        dir = new Vector3(0f, -0.1f);
        projectile = Instantiate(beeS, transform.position + dir, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * projectileLaunchForce, ForceMode2D.Impulse);
        
        // SW
        dir = new Vector3(-0.1f, -0.1f);
        projectile = Instantiate(beeSW, transform.position + dir, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * projectileLaunchForce, ForceMode2D.Impulse);
        
        // W
        dir = new Vector3(-0.1f, 0f);
        projectile = Instantiate(beeW, transform.position + dir, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * projectileLaunchForce, ForceMode2D.Impulse);

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }
}
