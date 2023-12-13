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
    private int startingColorIndex = 0;
    private int targetColorIndex = 1;
    private float currentColorIndex;

    private void OnTriggerEnter(Collider other)
    {
        material = other.GetComponent<Renderer>().material;
        //colors.Add(material.GetColor("_Color"));
        MetalHeatingUp();
    }

    private void OnTriggerExit()
    {
        MetalCoolingDown();
    }

    /// <summary>
    /// Shifts the color of the game object to the set color
    /// </summary>
    private void MetalHeatingUp()
    {
        //while (currentColorIndex < 1)
        //{
            currentColorIndex += Time.fixedTime;
            material.color = Color.Lerp(colors[startingColorIndex], colors[targetColorIndex], currentColorIndex);
        //}
    }

    /// <summary>
    /// Shifts the color of the game object back to the original color
    /// </summary>
    private void MetalCoolingDown()
    {
        while (currentColorIndex > 0)
        {
            currentColorIndex -= Time.deltaTime;
            material.color = Color.Lerp(colors[startingColorIndex], colors[targetColorIndex], currentColorIndex);
        }
    }
}
