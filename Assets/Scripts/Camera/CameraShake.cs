using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Vector3 m_initialPosition;
    public float m_elapsedShakingTime = 0f;
    public float m_shakingTime = 0f;
    [Range(0, 1)] public float m_smoothness = 0f;
    public float m_shakeIntensity = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShakeCamera(shakingTime: .05f);
        }
    }
    
    private void ShakeCamera(float shakingTime)
    {
        m_initialPosition = transform.position;
        StartCoroutine(CameraShakeCoroutine());
    }
    private IEnumerator CameraShakeCoroutine()
    {
        m_elapsedShakingTime = 0f;

        while (m_elapsedShakingTime <= m_shakingTime)
        {
            // 2
            Vector2 randomPoint = (Vector2)m_initialPosition + Random.insideUnitCircle * m_shakeIntensity;
            float randomXPoint = Random.Range(-0.15f, 0.15f) * m_shakeIntensity;
            Vector3 randomPointVect3 = new Vector3(randomXPoint, transform.position.y, -10f);
            transform.position = Vector3.Lerp(transform.position, randomPointVect3, Time.deltaTime * m_smoothness);

            // 3
            //float negativeX = Mathf.Abs(m_initialPosition.x) - 0.5f;
            //float positiveX = Mathf.Abs(m_initialPosition.x) + 0.5f;
            //Vector3 pointA = new Vector3(negativeX, transform.position.y, -10);
            //Vector3 pointB = new Vector3(positiveX, transform.position.y, -10);
            //transform.position = Vector3.Lerp(pointA, pointB, Time.deltaTime * m_smoothness);

            // 1
            //float randomX = Random.Range(-0.5f, 0.5f);
            //Vector3 pointA = transform.position;
            //Vector3 pointB = new Vector3(randomX, 0, -10);
            //transform.position = Vector3.Lerp(pointA, pointB, 0.5f);

            m_elapsedShakingTime += Time.deltaTime;
            yield return null;
        }
        this.transform.position = m_initialPosition;
    }
}