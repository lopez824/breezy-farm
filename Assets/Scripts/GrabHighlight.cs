using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHighlight : MonoBehaviour
{
    public Material highlight;
    private Material currentMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            currentMaterial = other.gameObject.GetComponent<MeshRenderer>().material;
            other.gameObject.GetComponent<MeshRenderer>().material = highlight;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = currentMaterial;
        }
    }
}
