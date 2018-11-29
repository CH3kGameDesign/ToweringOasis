using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightRotation : MonoBehaviour {

    public float SpeedX = 0f;
    public float SpeedY = 0f;
    public float SpeedZ = 1f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles += new Vector3(SpeedX, SpeedY, SpeedZ);
    }
}
