using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPyroState : PlayerBaseState
{
    
    public override void EnterState(PlayerStateManager player)
    {
        Pyro = false;
        Bola = true;
        Palo = false;
        Debug.Log("Helo pyro state");
    }
    public override void UpdateState(PlayerStateManager player)
    {
        if (Palo)
        {
            player.SwitchState(player.PyroState);
        }
    }
}
