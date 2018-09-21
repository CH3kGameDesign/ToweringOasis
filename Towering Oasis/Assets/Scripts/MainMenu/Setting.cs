using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Seizon
{
    public class Setting : MonoBehaviour
    {
        //Create Resolution List to Store Resolutions.
        List<Resolution> m_Resolutions = new List<Resolution>();
        //Get Dropdown and Toggle for resolution and fullscreen.
        public Dropdown m_ResolutionDropdownMenu;
        public Toggle m_FullscreenToggle;
        //Get Dropdown for Quality.
        public Dropdown m_QualityDropdownMenu;
        //Get Slider and InputField for Audio.
        public Slider m_AudioSlider;
        public InputField m_AudioInputField;
        float m_fInput;
        //Get This Menu and Previous Menu
        public GameObject m_ThisMenu;
        public GameObject m_PrevMenu;

        private void Awake()
        {
            for (int i = 0; i < Screen.resolutions.Length; ++i)
            {
                m_Resolutions.Add(Screen.resolutions[i]);
            }

            m_FullscreenToggle.isOn = Screen.fullScreen;

            GetResolutions();

        }

        //Use this for initialization.
        void Start()
        {
            for(int i = 0; i < 6; i++)
            {
                if (QualitySettings.GetQualityLevel() == i)
                    m_QualityDropdownMenu.value = i;
            }
            m_AudioSlider.value = AudioListener.volume * 100;
            m_fInput = m_AudioSlider.value;
            m_AudioInputField.text = m_fInput.ToString() + "%";
            m_AudioSlider.maxValue = 100;
            m_AudioSlider.wholeNumbers = true;
        }

        //Update is called once per frame.
        void Update()
        {
        }

        //Finds Resolutions and removes duplicates.
        private void GetResolutions()
        {
            for (int i = 0; i < m_Resolutions.Count; i++)
            {
                m_ResolutionDropdownMenu.options[i].text = RezToString(m_Resolutions[i]);
                m_ResolutionDropdownMenu.options.Add(new Dropdown.OptionData(m_ResolutionDropdownMenu.options[i].text));
            }

            m_ResolutionDropdownMenu.options.RemoveAt(m_Resolutions.Count);
            for (int i = 1; i < m_Resolutions.Count; i++)
            {
                if (m_ResolutionDropdownMenu.options[i - 1].text == m_ResolutionDropdownMenu.options[i].text)
                {
                    m_ResolutionDropdownMenu.options.RemoveAt(i);
                    m_Resolutions.RemoveAt(i);
                }
                if (m_ResolutionDropdownMenu.options[i - 1].text == m_ResolutionDropdownMenu.options[i].text)
                {
                    m_ResolutionDropdownMenu.options.RemoveAt(i);
                    m_Resolutions.RemoveAt(i);
                }
                if (m_ResolutionDropdownMenu.options[i - 1].text == m_ResolutionDropdownMenu.options[i].text)
                {
                    m_ResolutionDropdownMenu.options.RemoveAt(i);
                    m_Resolutions.RemoveAt(i);
                }
            }

            for (int i = 0; i < m_ResolutionDropdownMenu.options.Count; i++)
            {
                if (Screen.width == m_Resolutions[i].width && Screen.height == m_Resolutions[i].height)
                {
                    m_ResolutionDropdownMenu.value = i;
                }
            }
        }

        //Convert Resolution to String.
        string RezToString(Resolution r)
        {
            return r.width + "x" + r.height;
        }
        
        //Called when Resolution Dropdown value is changed and when fullscreen is toggle.
        public void OnResolutionChanged()
        {
            Screen.SetResolution(m_Resolutions[m_ResolutionDropdownMenu.value].width,
                                 m_Resolutions[m_ResolutionDropdownMenu.value].height,
                                 m_FullscreenToggle.isOn);
        }

        //Called when Quality Dropdown value is changed.
        public void OnQualityChanged()
        {
            QualitySettings.SetQualityLevel(m_QualityDropdownMenu.value);
        }

        //Called when Audio Slider is moved.
        public void AudioSliderValueChanged()
        {
            AudioListener.volume = m_AudioSlider.value / 100;
            m_fInput = m_AudioSlider.value;
            m_AudioInputField.text = m_fInput.ToString() + "%";
        }

        //Called when Audio Input Field Value is changed
        public void AudioInputFieldValueChanged()
        {
            m_fInput = float.Parse(m_AudioInputField.text);
            AudioListener.volume = m_fInput / 100;
            m_AudioSlider.value = m_fInput;
        }

        //Called when Return Button is pressed
        public void ReturnButtonPressed()
        {
            m_PrevMenu.SetActive(true);
            m_ThisMenu.SetActive(false);
        }
    }
}