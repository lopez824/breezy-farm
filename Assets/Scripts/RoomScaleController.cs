using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomScaleController : MonoBehaviour
{
    private IEnumerator coroutine;
    private IEnumerator jumpRoutine;

    private Vector3 playerPos; // keeps track of head set position.
    private float delay = 2.0f; // arbitrary time for player to stand straight and record height.
    private float airTime = 2.0f; // generous amount of seconds for a jump.
    private float yOffSet = 0.5f; // used to position collider's origin to half of the headset's height.
    private float heightOffSet = 1.1f; // used to position collider's max height a little underneath the headset.
    private float standingHeight; // captures player height.
    //private float jumpSensitivity = 0.08f; // used to determine if a player is jumping.

    public static bool isJumping;

    public Transform cameraAnchor;
    public CapsuleCollider player;
    public TextMeshProUGUI debugText;

    // Start is called before the first frame update
    private void Start()
    {
        isJumping = false;

        coroutine = getStandingHeight();
        StartCoroutine(coroutine);
    }

    /// <summary>
    /// Register Player's standing height.
    /// </summary>
    /// <returns></returns>
    private IEnumerator getStandingHeight()
    {
        yield return new WaitForSeconds(delay);
        standingHeight = cameraAnchor.localPosition.y;
        //GameManager.playerHeight = standingHeight;
    }

    /// <summary>
    /// Activate jumping mechanic.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Jumping()
    {
        yield return new WaitForSeconds(airTime);
        player.enabled = true;
        isJumping = false;
    }

    /// <summary>
    /// Checks if player is jumping, and also makes sure this only happens in a specific part of the scene.
    /// </summary>
    //private void checkJump()
    //{
    //    if (cameraAnchor.localPosition.y >= standingHeight + jumpSensitivity && isJumping == false && GameManager.jumpZone == true)
    //    {
    //        isJumping = true;
    //        player.enabled = false;

    //        jumpRoutine = Jumping();
    //        StartCoroutine(jumpRoutine);
    //    }

    //}

    // Updates collider height every frame to match headset height.
    private void FixedUpdate()
    {

        playerPos = cameraAnchor.localPosition;
        playerPos.y = cameraAnchor.localPosition.y * yOffSet;
        player.transform.position = playerPos;
        player.height = cameraAnchor.localPosition.y * heightOffSet;
        //debugText.text = player.transform.position.ToString();
        //checkJump();
    }
}
