using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    public Sprite[] m_Sprites;
    public Image m_ThisSprite;
    int m_selected;
    public static Dictionary<string, int> m_dictionary;

    // Use this for initialization
    void Start ()
    {
        m_dictionary = new Dictionary<string, int>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void UpArrowClick()
    {
        m_selected--;
        if (m_selected < 0)
            m_selected = m_Sprites.Length -1;
        m_ThisSprite.sprite = m_Sprites[m_selected];
    }

    public void DownArrowClick()
    {
        m_selected++;
        if (m_selected > m_Sprites.Length -1)
            m_selected = 0;
        m_ThisSprite.sprite = m_Sprites[m_selected];
    }

    public void SaveButtonClick()
    {
        m_dictionary.Remove(m_ThisSprite.name);
        m_dictionary.Add(m_ThisSprite.name, m_selected);
    }

    public void LoadButtonClick()
    {
        Debug.Log(m_dictionary[m_ThisSprite.name]);
        m_selected = m_dictionary[m_ThisSprite.name];
        m_ThisSprite.sprite = m_Sprites[m_selected];
    }
}
