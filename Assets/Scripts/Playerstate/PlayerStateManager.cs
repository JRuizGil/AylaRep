using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerStartingState StartingState = new PlayerStartingState();
    public PlayerPyroState PyroState = new PlayerPyroState();
    public PlayerPuenteState PuenteState = new PlayerPuenteState();

    void Start()
    {

        currentState = StartingState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
