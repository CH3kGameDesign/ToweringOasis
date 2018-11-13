using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboardsprites : MonoBehaviour
{

	public Transform MyCameraTransform;
	private Transform MyTransform;
	public bool alignNotLook = true;

	// Use this for initialization
	void Start()
	{
		MyTransform = this.transform;
		MyCameraTransform = Camera.main.transform;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (alignNotLook)
		{
			MyTransform.forward = -MyCameraTransform.forward;
			transform.localEulerAngles += new Vector3(90, 0, 0);
		}
		else
			MyTransform.LookAt(MyCameraTransform, Vector3.up);
	}
}