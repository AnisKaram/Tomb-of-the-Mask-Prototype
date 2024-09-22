using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region Fields
    private static ObjectPool m_instance;

    private List<GameObject> m_pool;
    private List<GameObject> m_poolOfUsedObjects;

    private bool m_isPoolAvailable;
    private GameObject m_objectAvailableInPool;
    #endregion

    #region Properties
    public static ObjectPool instance => m_instance;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
    }
    #endregion

    #region Public Methods
    public void CreatePool(GameObject objectInPool, int size = 20)
    {
        // Safety check
        if (m_isPoolAvailable)
        {
            Debug.Log($"Can't create one, pool is already available");
            return;
        }

        // Creating pool...
        m_objectAvailableInPool = objectInPool;
        m_pool = new List<GameObject>();
        m_poolOfUsedObjects = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject objectInstance = Instantiate(m_objectAvailableInPool);
            objectInstance.SetActive(false);
            m_pool.Add(objectInstance);
        }

        m_isPoolAvailable = true;
    }
    public void ExtendPool(GameObject objectInPool, int size = 20)
    {
        // Safety check
        if (!m_isPoolAvailable || !Object.Equals(objectInPool, m_objectAvailableInPool))
        {
            Debug.Log($"Pool is not available, please create one or pass the same object in pool");
            return;
        }

        // Extending the pool...
        for (int i = 0; i < size; i++)
        {
            GameObject objectInstance = Instantiate(objectInPool);
            objectInstance.SetActive(false);
            m_pool.Add(objectInstance);
        }
    }

    public GameObject GetObjectFromPool()
    {
        // Safety check
        if (m_isPoolAvailable && m_pool.Count > 0)
        {
            // Returning object from pool...
            int index = m_pool.Count - 1;
            GameObject objectToReturn = m_pool[index];

            m_pool.RemoveAt(index);
            m_poolOfUsedObjects.Add(objectToReturn);

            objectToReturn.SetActive(true);

            return objectToReturn;
        }

        Debug.Log($"No Objects are available or Pool is not available");
        return null;
    }
    public void ReleaseObjectToPool(GameObject objectToRelease)
    {
        // Safety check
        if (!m_isPoolAvailable || m_poolOfUsedObjects.Count == 0)
        {
            Debug.Log($"All Objects are released or Pool is not available");
            return;
        }

        // Releasing...
        objectToRelease.SetActive(false);

        // Remove the object from the used pool
        m_poolOfUsedObjects.Remove(objectToRelease);

        // Release the object back to the pool
        m_pool.Add(objectToRelease);
    }

    public bool IsUsedPoolFull()
    {
        return m_isPoolAvailable && m_pool.Count == 0;
    }
    #endregion
}