using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : MonoBehaviour
{
    private float tickLength = 1f;
    private float damagePerTick = 1f;
    private uint numTicks = 5;
    private float showGFXTime = 0.2f;
    private HasHealth hh;
    
    private void Awake()
    {
        hh = GetComponent<HasHealth>();
        StartCoroutine(Burn());
    }

    private IEnumerator Burn()
    {
        for (uint i = 0; i < numTicks; ++i)
        {
            yield return new WaitForSeconds(tickLength-showGFXTime);
            StartCoroutine(BurnGFX());
        }
    }

    private IEnumerator BurnGFX()
    {
        hh.fire.SetActive(true);
        yield return new WaitForSeconds(showGFXTime);
        hh.fire.SetActive(false);
        hh.TakeDamage(damagePerTick);
    }
}
