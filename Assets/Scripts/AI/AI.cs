using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform player;
    public GameObject[] waypoints;
    public GameObject[] penWaypoints;
    [HideInInspector]
    public bool isHeld = false;
    [HideInInspector]
    public bool onLand = true;
    [HideInInspector]
    public bool inPen = false;
    private Animator anim;
    private State currentState;
    private OVRGrabbable ovrGrabbable;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        currentState = new Idle(gameObject, anim, player, waypoints);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            onLand = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
        if (ovrGrabbable.isGrabbed == true)
            isHeld = true;
        else
            isHeld = false;
    }
}
