using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Held : State
{
    public Held(GameObject _npc, Animator _anim, Transform _player, GameObject[] _waypoints) : base(_npc, _anim, _player, _waypoints)
    {
        name = STATE.HELD;
    }

    public override void Enter()
    {
        // play held animation
        // anim.SetTrigger();
        Debug.Log("DebugLog - Held");
        ai.GetComponent<AI>().onLand = false;
        base.Enter();
    }

    public override void Update()
    {
        // determine what to do in this state
        if (ai.GetComponent<AI>().isHeld == false)
        {
            nextState = new Airborne(ai, anim, player, waypoints);      // randomly decide when to roam
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        // reset held animation
        // anim.ResetTrigger();
        base.Exit();
    }
}
