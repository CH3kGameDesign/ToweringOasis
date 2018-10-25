using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCamera : MonoBehaviour {

    public float speed;
    public float spriteChangeSpeed;

    public float rotMax;

    private float rotX;
    private float rotY;
    private float rotZ;

    private float rotXPrev;
    private float rotYPrev;
    private float rotZPrev;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (rotXPrev < rotX + 0.5f && rotXPrev > rotX - 0.5f)
        {
            Debug.Log("X");
            rotX = Random.Range(-rotMax, rotMax);
        }
        if (rotYPrev < rotY + 0.5f && rotYPrev > rotY - 0.5f)
        {
            Debug.Log("Y");
            rotY = Random.Range(-rotMax, rotMax);
        }
        if (rotZPrev < rotZ + 0.5f && rotZPrev > rotZ - 0.5f)
        {
            Debug.Log("Z");
            rotZ = Random.Range(-rotMax, rotMax);
        }

        rotXPrev = Mathf.Lerp(rotXPrev, rotX, Time.deltaTime * speed);
        rotYPrev = Mathf.Lerp(rotYPrev, rotY, Time.deltaTime * speed);
        rotZPrev = Mathf.Lerp(rotZPrev, rotZ, Time.deltaTime * speed);
        transform.rotation = Quaternion.Euler(rotXPrev, rotYPrev, rotZPrev);

        Debug.Log(transform.eulerAngles.x + " == " + rotX);

        if (Time.fixedTime > spriteChangeSpeed)
        {
            int targetSprite = Random.Range(0, GameObject.Find("Sprites").transform.childCount);
            for (int i = 0; i < GameObject.Find("Sprites").transform.childCount; i++)
            {
                if (i == targetSprite)
                {
                    GameObject.Find("Sprites").transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                    GameObject.Find("Sprites").transform.GetChild(i).gameObject.SetActive(false);
            }
            spriteChangeSpeed += Time.fixedTime;
        }
    }
}
