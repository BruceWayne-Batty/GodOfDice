using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DemoSceneController : MonoBehaviour
{
    public GameObject[] grids;

    public Slider baseSlider;
    public Slider dieSlider;

    public InputField baseColorInput;
    public InputField dieColorInput;

    private void Awake() {
        baseColorInput.text = "FFFFFF";
        dieColorInput.text = "000000";
        baseSlider.value = baseSlider.maxValue;
    }

    // Update is called once per frame
    public void UpdateColor()
    {
        int base_value = (int)(baseSlider.value);
        baseColorInput.text = base_value.ToString( "x6" );

        float base_red = ((base_value >> 16) & 255) / 255f;
        float base_green = ((base_value >> 8) & 255) / 255f;
        float base_blue = (base_value & 255) / 255f;

        Color base_color = new Color( base_red, base_green, base_blue );

        int die_value = (int)(dieSlider.value);
        dieColorInput.text = die_value.ToString( "x6" );

        float die_red = ((die_value >> 16) & 255) / 255f;
        float die_green = ((die_value >> 8) & 255) / 255f;
        float die_blue = (die_value & 255) / 255f;

        Color die_color = new Color( die_red, die_green, die_blue );

        ChangeDiceColor( base_color, die_color );
    }

    public void ChangeDiceColor(Color base_color, Color die_color) {
        foreach (GameObject grid in grids) {
            for (int i = 0; i < grid.transform.childCount; i++) {
                GameObject child = grid.transform.GetChild( i ).gameObject;
                Image base_img = child.GetComponentInChildren<Image>();
                Image die_img = child.transform.GetChild( 0 ).GetComponentInChildren<Image>();

                base_img.color = base_color;
                die_img.color = die_color;
            }
        }
    }

    public void UpdateColorInput() {

        string base_string = "#" + baseColorInput.text;
        Color base_color;
        if (ColorUtility.TryParseHtmlString( base_string, out base_color )) {
            Color32 base_color_byte = (Color32)(base_color);
            baseSlider.value = BitConverter.ToInt32( new byte[] { base_color_byte.b, base_color_byte.g, base_color_byte.r, 0 }, 0 );
        }

        string die_string = "#" + dieColorInput.text;
        Color die_color;
        if( ColorUtility.TryParseHtmlString(die_string, out die_color )) {
            Color32 die_color_byte = (Color32)(die_color);
            dieSlider.value = BitConverter.ToInt32( new byte[] { die_color_byte.b, die_color_byte.g, die_color_byte.r, 0 }, 0 );
        }
        UpdateColor();
    }
}
