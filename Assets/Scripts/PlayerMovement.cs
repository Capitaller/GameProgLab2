using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] Scenes sc;
    private ScoreManager sm;
    public bool playerIsGrounded;
   // private ScoreManager sm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && playerIsGrounded)
        {
            Jump();
        }
        
        var playerObject = GameObject.Find("Player");
        var playerPos = playerObject.transform.position;
        if (playerPos.y < -5)
        {
            sc = FindObjectOfType<Scenes>();
            sc.NextLevel("Scene1");

        }
        
    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

    }

    private void OnCollisionStay(Collision Coll)
    {
        if (Coll.gameObject.tag == "Plate")
        {
            playerIsGrounded = true;

        }


    }
    private void OnCollisionExit(Collision Coll)
    {
        if (Coll.gameObject.tag == "Plate")
        {
            playerIsGrounded = false;

        }


    }
    void OnTriggerEnter(Collider Coll)
    {
        // sm = FindObjectOfType<ScoreManager>();
        sm = FindObjectOfType<ScoreManager>();
        if (Coll.gameObject.tag == "Finish" && sm.score >= 3)
        {
            sc = FindObjectOfType<Scenes>();
            sc.NextLevel("Scene2");

        }

    }
}