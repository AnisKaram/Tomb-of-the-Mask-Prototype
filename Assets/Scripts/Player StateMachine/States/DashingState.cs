using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingState : IState
{
    private PlayerController m_playerController;

    public DashingState(PlayerController playerController)
    {
        this.m_playerController = playerController;
    }

    public void Enter()
    {
        //Debug.Log($"Entering dashing state");
    }

    public void Exit()
    {
        //Debug.Log($"Exiting dashing state");
    }

    public void Update()
    {
        if (!m_playerController.isDashing)
        {
            m_playerController.stateMachine.TransitionTo(m_playerController.stateMachine.idleState);
        }
    }
}