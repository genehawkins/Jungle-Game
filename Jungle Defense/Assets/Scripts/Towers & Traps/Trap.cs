using System;
using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] protected GameObject[] parts;
    private int numUses;
    [SerializeField] private float cooldownTimer = 2.0f;
    
    private void Awake()
    {
        numUses = parts.Length;
        GameManager.instance.SetupPhase.AddListener(ResetParts);
    }
    
    private IEnumerator Co_Cooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);
        ResetParts();
    }

    private void ResetParts()
    {
        numUses = parts.Length;
        foreach (var part in parts)
        {
            part.SetActive(true);
        }
    }
    
    //If collider detects an enemy, runs damage script
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (!enemy.CompareTag("Enemy") || numUses <= 0) return;
        
        TrapEffect(enemy);

        // Removes vine graphics as trap is used up
        var partNum = parts.Length - numUses;
        parts[partNum].SetActive(false);
        
        // Reduce the number of uses
        numUses--;

        if (numUses <= 0)
        {
            StartCoroutine(Co_Cooldown());
        }
    }

    protected virtual void TrapEffect(Collider2D enemy)
    {
        throw new NotImplementedException();
    }
}