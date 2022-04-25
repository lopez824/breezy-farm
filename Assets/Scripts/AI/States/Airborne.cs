using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airborne : State
{
    public Airborne(GameObject _npc, Animator _anim, Transform _player, GameObject[] _waypoints) : base(_npc, _anim, _player, _waypoints)
    {
        name = STATE.THROWN;
    }

    public override void Enter()
    {
        // play thrown animation
        // anim.SetTrigger();
        Debug.Log("DebugLog - Airborne");
        base.Enter();
    }

    public override void Update()
    {
        // determine what to do in this state
        if (ai.GetComponent<AI>().onLand == true)
        {
            nextState = new Idle(ai, anim, player, waypoints);      // randomly decide when to roam
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        // reset thrown animation
        // anim.ResetTrigger();
        base.Exit();
    }
}
