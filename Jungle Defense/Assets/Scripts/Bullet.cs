using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 200f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
        Debug.Log("bullet    " + col.gameObject.name);
    }
}
