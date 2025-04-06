using UnityEngine;

public class PlayerParticleController : MonoBehaviour
{
    #region Fields
    // Added according to the swipe direction enum order.
    private float[] m_groundParticleAngles = new float[] { 180, 0, 90, -90 };
    #endregion


    #region Public Methods
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
    #endregion
}