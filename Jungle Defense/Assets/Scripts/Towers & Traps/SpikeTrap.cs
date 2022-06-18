using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int numUses = 3;

    public GameObject spike1;
    public GameObject spike2;

    //If collider detects an enemy, runs damage script
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (!enemy.CompareTag("Enemy")) return;
        
        numUses--;

        //Debug.Log("An enemy hit us");
        enemy.GetComponent<HasHealth>().TakeDamage();

        //Spike graphics are removed as the trap is used up
        switch (numUses)
        {
            case 2:
                spike1.SetActive(false);
                break;
            
            case 1:
                spike2.SetActive(false);
                break;
            
            case 0:
                Destroy(gameObject);
                break;
            
            default:
                Debug.Log("SpikeTrap.cs switch statement reached Default");
                break;
        }
    }
}
