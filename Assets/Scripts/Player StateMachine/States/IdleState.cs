using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController m_playerController;
    private bool m_canPlayGroundEffect;

    public IdleState(PlayerController playerController, bool canPlayGroundEffect)
    {
        this.m_playerController = playerController;
        this.m_canPlayGroundEffect = canPlayGroundEffect;
    }

    public void Enter()
    {
        //Debug.Log($"Entering idle state");
        if (m_canPlayGroundEffect)
        {
            ParticleSystem groundInstance = m_playerController.playerParticleController.GetGroundParticle();
            m_playerController.playerParticleController.ChangeParticleRotation(groundInstance, (int)m_playerController.swipeDirection, m_playerController.transform.position);
            m_playerController.playerParticleController.PlayGroundParticle(groundInstance);
            m_canPlayGroundEffect = false;
        }
    }

    public void Exit()
    {
        //Debug.Log($"Exiting idle state");
        m_canPlayGroundEffect = true;
    }

    public void Update()
    {
        if (m_playerController.isDashing)
        {
            m_playerController.stateMachine.TransitionTo(m_playerController.stateMachine.dashingState);
        }
    }
}