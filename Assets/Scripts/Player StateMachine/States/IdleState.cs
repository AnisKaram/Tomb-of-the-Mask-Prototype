using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController m_playerController;

    public IdleState(PlayerController playerController)
    {
        this.m_playerController = playerController;
    }

    public void Enter()
    {
        //Debug.Log($"Entering idle state");
    }

    public void Exit()
    {
        //Debug.Log($"Exiting idle state");
    }

    public void Update()
    {
        if (m_playerController.isDashing)
        {
            m_playerController.stateMachine.TransitionTo(m_playerController.stateMachine.dashingState);
        }
    }
}