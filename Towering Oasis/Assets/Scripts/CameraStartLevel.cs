using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartLevel : MonoBehaviour
{
    Vector3 m_prevPos;

	void Start ()
    {
        m_prevPos = transform.position;        
	}
}
