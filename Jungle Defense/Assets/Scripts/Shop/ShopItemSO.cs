using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "scriptable objects/New shop item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public int apCost;
    public string desc;
    public int cost;
    
    public GameObject card;
}
