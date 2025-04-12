using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 15f;            
    public float rotationSpeed = 100f;     
    public float hoverHeight = 4f;         
    public float smoothPosition = 5f;       
    public float smoothRotation = 5f;       
    public float gravity = 9.81f;          
    private Vector3 velocity;               

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float targetY = hit.point.y + hoverHeight;
            Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothPosition);

            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothRotation);

            if (Mathf.Abs(transform.position.y - targetY) < 0.1f)
                velocity.y = 0;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
