using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Ball ball;
    public GameObject playerCamera;

    public float ballDistance = 2f;
    public float ballThrowingforce = 550f;
    public Rigidbody rb;

    public bool holdingBall = true;

    // Start is called before the first frame update
    void Start()
    {

        rb = ball.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBall)
        {
            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;
            
            if(Input.GetMouseButtonDown(0))
            {
                holdingBall = false;
                //ball.ActivateTrail();
                rb.useGravity = true;
                rb.AddForce(playerCamera.transform.forward * ballThrowingforce);
            }
        }
    }
}
