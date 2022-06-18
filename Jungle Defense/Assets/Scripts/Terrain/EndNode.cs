using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNode : MonoBehaviour
{
    [SerializeField] private GameObject fogGameObject;

    public void ToggleFog(bool toggle)
    {
        fogGameObject.SetActive(toggle);
    }
}
