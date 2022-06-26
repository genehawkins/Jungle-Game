using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTree : MonoBehaviour
{
    [SerializeField] private Sprite fullTree;  
    [SerializeField] private Sprite mostlyTree;
    [SerializeField] private Sprite kindaTree;
    [SerializeField] private Sprite barelyTree;

    public SpriteRenderer spriteRend;

    void Start()
    {
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float health = GameManager.instance.baseHealth.GetBaseHealth();

        if (health >= 16) {
            spriteRend.sprite = fullTree;
        } else if (health <= 15 && health >= 11) {
            spriteRend.sprite = mostlyTree;
        } else if (health <= 10 && health >= 6) {
            spriteRend.sprite = kindaTree;
        } else {
            spriteRend.sprite = barelyTree;
        }
    }
}
