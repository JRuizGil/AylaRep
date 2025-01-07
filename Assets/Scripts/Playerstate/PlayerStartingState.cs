using Unity.VisualScripting;
using UnityEngine;

public class PlayerStartingState : PlayerBaseState
{
    public GameObject Bolaobj;
    public GameObject Player;    

    public override void EnterState(PlayerStateManager player)
    {
        Pyro = false;
        Bola = false;
        Debug.Log("Helo starting state");

    }
    public override void UpdateState(PlayerStateManager player)
    {
        EarnAbility();
        if (Bola && Pyro == false)
        {
            Pyro = true;
            Debug.Log("Cambiando a pyrostate");
            player.SwitchState(player.PyroState);
            
        }
        
    }
    public void EarnAbility()
    {
        if(!Bolaobj.activeSelf)
        {
            Bola = true;
            Debug.Log("habilidad cogida");
        }
    }
    

}
