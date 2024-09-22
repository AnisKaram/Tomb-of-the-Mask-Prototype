using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleController : MonoBehaviour
{
    public ParticleSystem m_groundParticle;
    private float[] m_groundParticleAngles = new float[] { 180, 0, 90, -90 };

    public void ChangeParticleRotation(int swipeDirectionIndex, Vector3 playerPosition)
    {
        Vector3 particleRotation = new Vector3(m_groundParticleAngles[swipeDirectionIndex], -90f, -90f);
        m_groundParticle.transform.eulerAngles = particleRotation;
        m_groundParticle.transform.position = playerPosition;
    }
    public void PlayGroundParticle()
    {
        m_groundParticle.Play();
    }
}