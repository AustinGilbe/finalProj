using UnityEngine;

public class MultiplayerCamera : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public Vector2 offset;
    public float smoothTime = 0.3f;

    private Vector3 velocity;

    void LateUpdate()
    {
        Vector3 midpoint = (player1.position + player2.position) / 2f;
        Vector3 targetPosition = midpoint + new Vector3(offset.x, offset.y, transform.position.z);
        targetPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        Vector3 direction = -(player1.position - player2.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothTime);
    }
}

