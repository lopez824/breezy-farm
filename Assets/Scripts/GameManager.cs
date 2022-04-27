using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator millAnim;

    // Start is called before the first frame update
    void Start()
    {
        millAnim.Play("mill");
    }
}
