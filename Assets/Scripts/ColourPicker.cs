using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
[ExecuteInEditMode]
public class ColourPicker : MonoBehaviour
{
    [SerializeField]float speed;
    Volume vol;
    ColorAdjustments color;
    private void Start()
    {
        vol = GetComponent<Volume>();
        vol.profile.TryGet(out color);
    }
    private void Update()
    {
        if (color) 
        {
            color.hueShift.value += speed;
            if (color.hueShift.value >= color.hueShift.max - speed*2) color.hueShift.value = color.hueShift.min;
        }
    }
}
