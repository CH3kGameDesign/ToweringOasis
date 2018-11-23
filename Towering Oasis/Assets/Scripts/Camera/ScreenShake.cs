using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance;
    public float shakeAmount = 1f;
    public float shakeTimer = 0.2f;
    public float shakeLength = 1.0f;

    // Use this for initialization
    private void Awake()
    {
        shakeTimer = 5;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

        // Update is called once per frame
    public void FixedUpdate()
    {
        if (shakeTimer < shakeLength)
            transform.localPosition = Random.insideUnitSphere * shakeAmount;
        else
            transform.localPosition = Vector3.zero;

        shakeTimer += Time.deltaTime;
	}
}
