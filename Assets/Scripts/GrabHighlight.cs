using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHighlight : MonoBehaviour
{
    public Material highlight;
    public Material pigHighlight;
    private Material currentMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            currentMaterial = other.gameObject.GetComponent<MeshRenderer>().material;
            other.gameObject.GetComponent<MeshRenderer>().material = highlight;
        }
        else if (other.gameObject.tag == "Piggy")
        {
            currentMaterial = other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
            other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = pigHighlight;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = currentMaterial;
        }
        else if (other.gameObject.tag == "Piggy")
        {
            other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = currentMaterial;
        }
    }
}
