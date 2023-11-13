using UnityEngine;

public class Player : MonoBehaviour
{
    public Ball ball;
    public GameObject playerCamera;

    public float ballDistance = 2f;
    public float maxThrowingForce = 1000f; // Adjust this value for the maximum throwing force
    public Rigidbody rb;

    public bool holdingBall = true;
    private float throwStartTime;

    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        if (holdingBall)
        {
            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

            if (Input.GetMouseButtonDown(0))
            {
                throwStartTime = Time.time;
            }

            if (Input.GetMouseButton(0))
            {
                // Calculate throwing force based on the duration the mouse button is held down
                float throwDuration = Time.time - throwStartTime;
                float normalizedThrowForce = Mathf.Clamp01(throwDuration / maxThrowingForce);
                float throwingForce = normalizedThrowForce * maxThrowingForce;

                // Optional: Visualize the throwing force (you can remove this line if not needed)
                Debug.Log("Throwing Force: " + throwingForce);

                // Update the ball's position based on the mouse movement (optional)
                ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * (ballDistance + throwDuration);

                // Note: You may want to add additional logic to limit the maximum throw distance

            }

            if (Input.GetMouseButtonUp(0))
            {
                holdingBall = false;
                rb.useGravity = true;

                // Apply the final throwing force
                rb.AddForce(playerCamera.transform.forward * maxThrowingForce);
            }
        }
    }
}
