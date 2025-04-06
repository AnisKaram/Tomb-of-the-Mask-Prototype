using UnityEngine;

/// <summary>
/// It's used to create a pool of ground effects.
/// </summary>
public class GroundEffectPoolCreator : MonoBehaviour
{
    #region Fields
    [Header("Ground Particle")]
    [SerializeField] private GameObject m_groundEffectPrefab;
    #endregion


    #region Unity Methods
    private void Start()
    {
        ObjectPool.instance.CreatePool(m_groundEffectPrefab, 10);
    }
    #endregion
}