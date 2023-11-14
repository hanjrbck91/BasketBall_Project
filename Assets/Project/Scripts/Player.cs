using UnityEngine;

public class Player : MonoBehaviour
{
    public Ball ballPrefab;  // Reference to the ball prefab
    public GameObject playerCamera;

    public float ballDistance = 2f;
    public float ballThrowingforce = 550f;
    private Rigidbody rb;
    private Ball currentBall;  // Reference to the currently held ball


    // Start is called before the first frame update
    void Start()
    {
        SpawnNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBall != null)
        {
            currentBall.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

            if (Input.GetMouseButtonDown(0))
            {
                ThrowBall();
            }
        }
    }

    void ThrowBall()
    {
        currentBall.Throw(ballThrowingforce,playerCamera.transform.forward);
        rb.useGravity = true;  // Enable gravity for the ball
        rb.freezeRotation = false;  // Allow rotation for the ball
        currentBall = null;

        // Invoke the SpawnNewBall method after a delay
        Invoke("SpawnNewBall", 1f);
    }

    void SpawnNewBall()
    {
        // Instantiate a new ball
        Ball newBall = Instantiate(ballPrefab, playerCamera.transform.position + playerCamera.transform.forward * ballDistance, Quaternion.identity);
        rb = newBall.GetComponent<Rigidbody>();
        rb.useGravity = false;  // Disable gravity for the new ball
        rb.freezeRotation = true;  // Freeze rotation for the new ball

        currentBall = newBall;  // Set the newly instantiated ball as the current ball

        Destroy(newBall, 10f);
    }
}
