using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int numUses = 3;

    public GameObject spike1;
    public GameObject spike2;

    //If collider detects an enemy, runs damage script
    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Enemy") {
            numUses--;

            //Debug.Log("An enemy hit us");
            enemy.GetComponent<HasHealth>().TakeDamage();

            //Spike graphics are removed as the trap is used up
            if (numUses == 2) {
                Destroy(spike1);
            } else if (numUses == 1) {
                Destroy(spike2);
            } else if (numUses <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
