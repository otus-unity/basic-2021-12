using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider slider;
    public AudioMixer audioMixer;
    public string groupName;
    
    void Start()
    {
        audioMixer.GetFloat(groupName, out var value);
        slider.value = value;
    }

    private void OnEnable()
    {
        slider.onValueChanged.AddListener(SliderValueChanged);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(SliderValueChanged);
    }

    private void SliderValueChanged(float value)
    {
        audioMixer.SetFloat(groupName, value);
    }
}
