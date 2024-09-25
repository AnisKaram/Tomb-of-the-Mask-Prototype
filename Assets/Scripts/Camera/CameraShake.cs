using System.Collections;
using UnityEngine;

public enum ShakeAxis { Xonly, Yonly, XY }

public class CameraShake : MonoBehaviour
{
    #region Fields
    [Header("Shake Settings")]
    [SerializeField] private float m_shakingTime = 0f;
    [SerializeField] private float m_shakeIntensity = 0f;
    [SerializeField] private ShakeAxis m_shakeAxis;
    #endregion


    #region Public Methods
    public void ShakeCamera()
    {
        StartCoroutine(CameraShakeCoroutine());
    }
    #endregion


    #region Private Methods
    private IEnumerator CameraShakeCoroutine()
    {
        float elapsedShakingTime = 0f;
        Vector3 initialPosition = transform.position;

        while (elapsedShakingTime < m_shakingTime)
        {
            Vector3 shakePosition = Vector3.zero;
            float x = Random.Range(-1f, 1f) * m_shakeIntensity;
            float y = Random.Range(-1f, 1f) * m_shakeIntensity;

            if (m_shakeAxis == ShakeAxis.Xonly) { shakePosition = new Vector3(x, initialPosition.y, initialPosition.z); }
            else if (m_shakeAxis == ShakeAxis.Yonly) { shakePosition = new Vector3(initialPosition.x, y, initialPosition.z); }
            else if (m_shakeAxis == ShakeAxis.XY) { shakePosition = new Vector3(x, y, initialPosition.z); }
            transform.position = shakePosition;

            elapsedShakingTime += Time.deltaTime;

            yield return null;
        }

        this.transform.position = initialPosition;
    }
    #endregion
}