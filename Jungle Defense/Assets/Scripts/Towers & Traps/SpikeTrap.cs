using System.Collections;
using UnityEngine;

public class SpikeTrap : Trap
{
    protected override void TrapEffect(Collider2D enemy)
    {
        enemy.GetComponent<HasHealth>().TakeDamage();
    }
}
