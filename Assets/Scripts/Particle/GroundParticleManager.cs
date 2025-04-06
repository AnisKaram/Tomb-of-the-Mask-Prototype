using System.Collections;
using UnityEngine;

/// <summary>
/// It's added as a component on the Particle_Ground prefab.
/// </summary>
public class GroundParticleManager : MonoBehaviour
{
    #region Fields
    private WaitForSeconds waitForSeconds = new WaitForSeconds(0.65f);
    #endregion


    #region Unity Methods
    private void OnEnable()
    {
        StartCoroutine(WaitAndReleaseObject());
    }
    private IEnumerator WaitAndReleaseObject()
    {
        yield return waitForSeconds;
        ObjectPool.instance.ReleaseObjectToPool(this.gameObject);
    }
    #endregion
}
