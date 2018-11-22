using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartLevel : MonoBehaviour
{
    public float m_lerpTime;
    public float m_delay;
    private bool m_lerpStart = false;

    GameObject exit;
    Vector3 m_prevPos;

	void Start ()
    {
        m_prevPos = transform.position;

        exit = GameObject.Find("M_TriggerExit (1)").transform.GetChild(0).transform.GetChild(0).gameObject;
        transform.position = exit.transform.position;
        Invoke("StartLerp", m_delay);
    }

    private void Update()
    {
        if (m_lerpStart)
            transform.position = Vector3.Lerp(transform.position, m_prevPos, m_lerpTime);
    }

    private void StartLerp()
    {
        m_lerpStart = true;
    }
}
