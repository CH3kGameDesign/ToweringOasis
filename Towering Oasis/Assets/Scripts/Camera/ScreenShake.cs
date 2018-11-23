using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance;
    public bool shake = false;
    public float shakeAmount = 1f;
    public float shakeTimer = 0f;
    public float shakeLength = 0.5f;

    // Use this for initialization
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

        // Update is called once per frame
    public void ShakeScreen()
    {
        if (shake)
            transform.localPosition = Random.insideUnitSphere * shakeAmount;
        else
            transform.localPosition = Vector3.zero;

        if (shakeTimer >= shakeLength)
            shake = false;

        shakeTimer += Time.deltaTime;
	}
}
