using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarHandOffset : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;

    private void Awake()
    {
        transform.localPosition += offset;
    }
}
