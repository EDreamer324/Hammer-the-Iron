using System.Collections;
using UnityEngine;

public class Smelting : MonoBehaviour
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

    IEnumerator LerpToTargetColor()
    {
        Debug.Log("heating started!");

        float elapsedFrames = 0;
        int targetColorIndex = 1;

        Color lerpedColor = Color.white;

        //The loop interpolates the values between the original color and the target color,
        //transitioning to the target color over time
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

    //2 different EaseIn functions to experiment with the lerp function
    public static float InQuint(float t) => Mathf.Pow(t, 5);
    public static float InOutQuint(float t)
		{
			if (t < 0.5) return InQuint(t * 2) / 2;
			return 1 - InQuint((1 - t) * 2) / 2;
		}

}
