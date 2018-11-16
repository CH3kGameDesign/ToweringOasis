using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniHealthBars : MonoBehaviour
{

    // Use this for initialization
    public Slider m_HPSlider;
	void Start ()
    {
        m_HPSlider.value = this.GetComponentInParent<Actor>().m_nHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (m_HPSlider.value != this.GetComponentInParent<Actor>().m_nHealth)
            m_HPSlider.value = this.GetComponentInParent<Actor>().m_nHealth;
    }
}
