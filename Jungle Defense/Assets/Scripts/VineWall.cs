using UnityEngine;

public class VineWall : MonoBehaviour
{
    [Header("Attributes")]
    public int numUses = 3;
    public float slowRate = 2;
    public float refreshTimer = 6f;

    [Header("Unity Setup")]
    public GameObject vine1;
    public GameObject vine2;
    public GameObject vine3;
    

    private float countdown = 0f;

    void OnTriggerEnter2D(Collider2D enemy)
    {
        //Detects enemy collisions and slows move speed
        if (enemy.tag == "Enemy") {
            //Debug.Log("We snared an enemy");
            if (numUses > 0) {
                enemy.GetComponent<EnemyMovement>().speed /= slowRate;
            }

            numUses--;

            //Removes vine graphics as trap is used up
            if (numUses == 2) {
                vine1.GetComponent<SpriteRenderer>().enabled = false;
            } else if (numUses == 1) {
                vine2.GetComponent<SpriteRenderer>().enabled = false;
            } else if (numUses <= 0) {
                vine3.GetComponent<SpriteRenderer>().enabled = false;
                countdown = refreshTimer; //Refresh timer starts when trap is used up
            }
        }
    }

    void Update()
    {
        //Counts down and resets vine trap
        if (countdown >= 0) {
            countdown -= Time.deltaTime;

            if (countdown <= 0) {
                vine1.GetComponent<SpriteRenderer>().enabled = true;
                vine2.GetComponent<SpriteRenderer>().enabled = true;
                vine3.GetComponent<SpriteRenderer>().enabled = true;
                numUses = 3;
            }
        }
    }


}
