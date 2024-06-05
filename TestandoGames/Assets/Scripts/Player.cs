using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D playerRB;
    [SerializeField] 
    float 
        speed,
        jumpForce,
        jumpingGravityScale;
    Vector2 initialJumpPosition;
    bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new(Input.GetAxis("Horizontal") * speed, isGrounded ? Input.GetAxis("Vertical") * speed : playerRB.velocity.y);

        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            initialJumpPosition = playerRB.position;
            isGrounded = false;
            playerRB.gravityScale = jumpingGravityScale;
            playerRB.velocity = new(playerRB.velocity.x, playerRB.velocity.y + jumpForce * speed);
        }
        if (!isGrounded )
        {
            if(playerRB.velocity.y < 0 && playerRB.position.y <= initialJumpPosition.y) 
            {
                isGrounded = true;
                playerRB.gravityScale = 0;
            }

        }
    }
}
