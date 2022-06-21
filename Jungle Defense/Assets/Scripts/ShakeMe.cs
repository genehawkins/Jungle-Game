using System.Collections;
using UnityEngine;

// https://youtu.be/-MZD_dZ41rI
public class ShakeMe : MonoBehaviour
{
    private bool alreadyShaking = false;
    private Vector3 originalPosition;
    [SerializeField] private float shakeAmount = 2f;
    private int shakeDirection = -1;

    private void Update()
    {
        if (!alreadyShaking) return;

        var newPos = transform.position;
        newPos.x += shakeDirection * Time.deltaTime * shakeAmount;
        shakeDirection = (shakeDirection is -1 or -2) ? 2 : -2;
        transform.position = newPos;
    }

    public void Shake()
    {
        if (alreadyShaking) return;

        StartCoroutine(Co_Shake());
    }

    private IEnumerator Co_Shake()
    {
        originalPosition = transform.position;
        alreadyShaking = true;
        yield return new WaitForSeconds(0.25f);
        alreadyShaking = false;
        transform.position = originalPosition;
    }
}
