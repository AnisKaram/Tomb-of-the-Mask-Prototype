using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Fields
    private PlayerController m_playerController;
    private Camera m_mainCamera;

    private int m_canMoveCamera = 0;

    private const float m_interpolationTime = 10f;
    private const float m_positionDifference = 0.05f;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        m_mainCamera = Camera.main;
        m_playerController = GetComponent<PlayerController>();
    }
    private void Start()
    {
        m_canMoveCamera = BinaryUtil.SetFlag(m_canMoveCamera, 1);
    }
    private void Update()
    {
        CheckIfCameraCanMove();
    }
    private void LateUpdate()
    {
        if (BinaryUtil.BitmaskAND(m_canMoveCamera, 1))
        {
            LerpCameraToPosition();
        }
    }
    #endregion


    #region Private Methods
    private void CheckIfCameraCanMove()
    {
        if (m_playerController.stateMachine.currentState == m_playerController.stateMachine.dashingState) { m_canMoveCamera = BinaryUtil.SetFlag(m_canMoveCamera, 1); }
    }

    private void LerpCameraToPosition()
    {
        Vector3 startPosition = m_mainCamera.transform.position;
        Vector3 endPosition = new Vector3(this.transform.position.x, this.transform.position.y, m_mainCamera.transform.position.z);
        Vector3 lerpPosition = Vector3.LerpUnclamped(startPosition, endPosition, m_interpolationTime * Time.deltaTime);

        m_mainCamera.transform.position = lerpPosition;

        if (IsInterpolationReached(startPosition, endPosition)) { m_canMoveCamera = BinaryUtil.SetFlag(m_canMoveCamera, 0); }
    }
    private bool IsInterpolationReached(Vector3 start, Vector3 end)
    { 
        return (Mathf.Abs(end.x - start.x) < m_positionDifference) && (Mathf.Abs(end.y - start.y) < m_positionDifference);
    }
    #endregion
}