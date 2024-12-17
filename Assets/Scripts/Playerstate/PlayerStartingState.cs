using Unity.VisualScripting;
using UnityEngine;

public class PlayerStartingState : PlayerBaseState
{
    
    public override void EnterState(PlayerStateManager player)
    {
        Pyro = false;
        Bola = false;
        Debug.Log("Helo starting state");

    }
    public override void UpdateState(PlayerStateManager player)
    {
        if (Bola)
        {
            player.SwitchState(player.PyroState);
        }
        
    }
}
