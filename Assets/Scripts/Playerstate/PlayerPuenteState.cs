using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPuenteState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Pyro = false;
        Debug.Log("Helo Puente state");
    }
    public override void UpdateState(PlayerStateManager player)
    {

    }
}
