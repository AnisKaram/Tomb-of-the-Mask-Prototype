using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    #region Fields
    [SerializeField] private float m_height;
    [SerializeField] private float m_width;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        ResizeOrthographicSize();
    }
    private void OnValidate()
    {
        ResizeOrthographicSize();
    }
    #endregion


    #region Private Methods
    private void ResizeOrthographicSize()
    {
        Camera camera = Camera.main;
        Vector3 position = camera.ViewportToWorldPoint(Vector3.zero);
        Vector3 up = camera.ViewportToWorldPoint(Vector3.up) - position;
        Vector3 right = camera.ViewportToWorldPoint(Vector3.right) - position;

        float newCameraSize = Mathf.Max(this.m_height, this.m_width * up.magnitude / right.magnitude);

        camera.orthographicSize = newCameraSize;
    }
    #endregion
}