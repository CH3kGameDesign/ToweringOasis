using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    public bool shake = false;
    public float shakeAmount = 1f;
    public float shakeTimer = 0f;
    public float shakeLength = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (shake)
            transform.localPosition = Random.insideUnitSphere * shakeAmount;
        else
            transform.localPosition = Vector3.zero;

        if (shakeTimer >= shakeLength)
            shake = false;

        shakeTimer += Time.deltaTime;
	}
}
