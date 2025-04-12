using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 13, -40);

    void LateUpdate()
    {
        Vector3 rotatedOffset = player.rotation * offset;

        transform.position = player.position + rotatedOffset;

        transform.LookAt(player);
    }
}
