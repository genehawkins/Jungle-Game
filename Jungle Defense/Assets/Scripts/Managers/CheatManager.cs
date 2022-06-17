using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    public KeyCode unlimitedMoneyKey = KeyCode.M;
    private bool unlimitedMoneyActive = false;
    
    private void Update()
    {
        CheckKeys();
        UnlimitedMoney();
    }

    private void CheckKeys()
    {
        // Unlimited Money
        if (Input.GetKeyDown(unlimitedMoneyKey))
        {
            if (!unlimitedMoneyActive)
            {
                Debug.Log("Activate Unlimited Money");
                unlimitedMoneyActive = true;
            }
            else
            {
                Debug.Log("DeActivate Unlimited Money");
                unlimitedMoneyActive = false;
            }
        }
    }

    private void UnlimitedMoney()
    {
        if (!unlimitedMoneyActive) return;
        if (MoneyManager.coins != 99)
            MoneyManager.Set(99);
    }
}
