using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public Transform MapLimiterTopLeft;
    public Transform MapLimiterBottomRight;
    new Transform transform;

    float cameraHalfWidth;
    float cameraHalfHeight;

    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        Camera camera = gameObject.GetComponent<Camera>();

        cameraHalfHeight = camera.orthographicSize;
        cameraHalfWidth = camera.aspect * cameraHalfHeight;
    }

    void Update()
    {
        float xPosition, yPosition;

        xPosition = Mathf.Clamp(
                Player.position.x,
                MapLimiterTopLeft.position.x + cameraHalfWidth,
                MapLimiterBottomRight.position.x - cameraHalfWidth
            );

        yPosition = Mathf.Clamp(
                Player.position.y,
                MapLimiterBottomRight.position.y + cameraHalfHeight,
                MapLimiterTopLeft.position.y - cameraHalfHeight
            );

        transform.position = new Vector3(xPosition, yPosition, transform.position.z);
    }
}
