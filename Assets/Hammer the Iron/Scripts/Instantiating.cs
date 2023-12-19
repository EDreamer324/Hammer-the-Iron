using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiating : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    private Vector3 instantiatePosition;

    public void Instantiatiate()
    {
        instantiatePosition = new Vector3(Random.Range(-5,5), 20, Random.Range(-5,5));
        Instantiate(sword, instantiatePosition, Quaternion.identity);
    }
}
