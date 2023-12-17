using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerping : MonoBehaviour
{
    [SerializeField] private Material objectMaterial;
    [SerializeField] private Color[] lerpColors;
    [SerializeField] private float lerpDuration;


    //For Debugging purposes
    private int timesLerped;

    private void OnTriggerEnter(Collider other)
    {
        //Gets the material attached to the object within the trigger
        objectMaterial = other.GetComponent<Renderer>().material;
        lerpColors[0] = objectMaterial.color;

        StartCoroutine(LerpToTargetColor());
    }

    private void OnTriggerExit()
    {
        StartCoroutine(LerpBackToOriginalColor());
    }

    IEnumerator LerpToTargetColor()
    {
        Debug.Log("heating started!");

        float elapsedFrames = 0;
        int targetColorIndex = 1;

        Color lerpedColor = Color.white;

        while (elapsedFrames < lerpDuration)
        {
            float t = elapsedFrames / lerpDuration;

            lerpedColor = Color.Lerp(objectMaterial.color, lerpColors[targetColorIndex], InOutQuint(t));
            elapsedFrames += Time.fixedDeltaTime;

            objectMaterial.SetColor("_Color", lerpedColor);

            timesLerped++;
            yield return new WaitForEndOfFrame();
        }
        
        Debug.Log("Color lerped " + timesLerped + " times!");
        timesLerped = 0;
    }

    /// <summary>
    /// Lerps the color back to the original color
    /// </summary>
    /// <returns></returns>
    IEnumerator LerpBackToOriginalColor()
    {
        Debug.Log("cooling started!");

        float elapsedFrames = 0;
        int originalColorIndex = 0;
        Color lerpedColor = Color.white;

        while (elapsedFrames < lerpDuration)
        {
            float t = elapsedFrames / lerpDuration;

            lerpedColor = Color.Lerp(objectMaterial.color, lerpColors[originalColorIndex], InOutQuint(t));
            elapsedFrames += Time.fixedDeltaTime;

            objectMaterial.SetColor("_Color", lerpedColor);

            timesLerped++;

            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Color lerped " + timesLerped + " times!");
        timesLerped = 0;

    }

    public static float InQuint(float t) => Mathf.Pow(t, 3);
    public static float InOutQuint(float t)
		{
			if (t < 0.5) return InQuint(t * 2) / 2;
			return 1 - InQuint((1 - t) * 2) / 2;
		}

}
