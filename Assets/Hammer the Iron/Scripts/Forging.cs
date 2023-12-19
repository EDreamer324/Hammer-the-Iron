using UnityEngine;

public class Forging : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    
    private int hitCounter;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Tool")
        {
            hitCounter++;
        }

        if (hitCounter == 3)
        {
            this.gameObject.SetActive(false);
            sword.SetActive(true);
        }
    }
}
