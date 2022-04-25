using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : State
{
    public Roaming(GameObject _npc, Animator _anim, Transform _player, GameObject[] _waypoints) : base(_npc, _anim, _player, _waypoints)
    {
        name = STATE.ROAMING;
        speed = 2;
    }

    public override void Enter()
    {
        // play roaming animation
        // anim.SetTrigger();
        currentPoint = Random.Range(0, waypoints.Length - 1);
        base.Enter();
    }

    public override void Update()
    {
        if (ai.GetComponent<AI>().isHeld == true)
        {
            nextState = new Held(ai, anim, player, waypoints);      // randomly decide when to roam
            stage = EVENT.EXIT;
        }

        if (CanSeePlayer() == true)
        {
            nextState = new Fleeing(ai, anim, player, waypoints);      // randomly decide when to roam
            stage = EVENT.EXIT;
        }

        destination = waypoints[currentPoint].transform.position;
        MoveTo(destination);

        if (GetDistanceTo(destination) < 1)
        {
            // move to next point
            if (Random.Range(0, 100) < 20f)
            {
                nextState = new Idle(ai, anim, player, waypoints);      // randomly decide when to roam
                stage = EVENT.EXIT;
            }

            if (currentPoint == 0 || currentPoint == 1)
                currentPoint = Random.Range(2, 6);
            else if (currentPoint == waypoints.Length - 1 || currentPoint == waypoints.Length - 2)
                currentPoint = Random.Range(10, 14);
            else
                currentPoint = Random.Range(0, waypoints.Length - 1);
        }
    }

    public override void Exit()
    {
        // reset roaming animation
        // anim.ResetTrigger();
        base.Exit();
    }
}
