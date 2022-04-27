using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleeing : State
{
    public Fleeing(GameObject _npc, Animator _anim, Transform _player, GameObject[] _waypoints) : base(_npc, _anim, _player, _waypoints)
    {
        name = STATE.FLEEING;
        speed = 2;
    }

    public override void Enter()
    {
        // play fleeing animation
        // anim.SetTrigger();
        ai.GetComponent<AI>().exclamAnim.Play("Exclamation");
        Debug.Log("DebugLog - Fleeing");
        base.Enter();
    }

    public override void Update()
    {
        if (ai.GetComponent<AI>().isHeld == true)
        {
            nextState = new Held(ai, anim, player, waypoints);      // randomly decide when to roam
            stage = EVENT.EXIT;
        }

        RunAway();
        // determine what to do in this state
        if (GetDistanceTo(player.position) > escapeDistance)
        {
            nextState = new Idle(ai, anim, player, waypoints);      // randomly decide when to roam
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        // reset fleeing animation
        // anim.ResetTrigger();
        base.Exit();
    }
}
