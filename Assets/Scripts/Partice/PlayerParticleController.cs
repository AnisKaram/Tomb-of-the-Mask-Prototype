using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleController : MonoBehaviour
{
    public ParticleSystem m_groundParticle;
    private float[] m_groundParticleAngles = new float[] { 180, 0, 90, -90 };

    public ParticleSystem GetGroundParticle()
    {
        ParticleSystem groundEffectInstance = Instantiate(m_groundParticle);
        return groundEffectInstance;
    }
    public void ChangeParticleRotation(ParticleSystem particleInstance, int swipeDirectionIndex, Vector3 playerPosition)
    {
        Vector3 particleRotation = new Vector3(m_groundParticleAngles[swipeDirectionIndex], -90f, -90f);
        particleInstance.transform.eulerAngles = particleRotation;
        particleInstance.transform.position = playerPosition;
    }
    public void PlayGroundParticle(ParticleSystem particleInstance)
    {
        particleInstance.Play();
    }
}