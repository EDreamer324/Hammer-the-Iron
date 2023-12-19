using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Smelting : MonoBehaviour
{
    //Variables used by the color shifting function
    [SerializeField] private Material material;
    [SerializeField] private Color[] colors;
    [SerializeField] private Color lerpedColor;
    private int startingColorIndex = 0;
    private int targetColorIndex = 1;
    private float timeSpentLerping = 0;
    private float timeToLerp = 5;
    int timesColorShifted;


    private void OnTriggerEnter(Collider other)
    {
        material = other.GetComponent<Renderer>().material;
        MetalHeatingUp();
    }

    private void OnTriggerExit()
    {
        MetalCoolingDown();
        material = null;
    }

    /// <summary>
    /// Shifts the color of the game object to the set color
    /// </summary>
    private void MetalHeatingUp()
    {
        while (timeSpentLerping < timeToLerp)
        {
            timeSpentLerping += Time.deltaTime;

            material.color = Color.Lerp(material.color, colors[targetColorIndex], timeSpentLerping);

            timesColorShifted++;
        }
        Debug.Log("Color has shifted " + timesColorShifted + " times");
        timesColorShifted = 0;
    }

    /// <summary>
    /// Shifts the color of the game object back to the original color
    /// </summary>
    private void MetalCoolingDown()
    {
        lerpedColor = Color.black;

        while (timeSpentLerping > 0)
        {
            timeSpentLerping -= Time.deltaTime;
            material.color = Color.Lerp(colors[startingColorIndex], colors[targetColorIndex], timeSpentLerping / timeToLerp);
        }
    }
}
