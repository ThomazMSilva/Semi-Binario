using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private float speed, movMagnitude;
    [SerializeField] private Light luz; 
    private Vector2 
        movement,
        lastMovement;

    void Update()
    {
        movement = new(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
        movMagnitude = movement.magnitude;

        if (movMagnitude != 0)
        {
            lastMovement = movement;
        }

        if(movement.x != 0)
        {
            if (movement.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
                transform.localRotation = Quaternion.identity;
        }
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        playerRB.velocity = movement;
    }
    
    void UpdateAnimation()
    {
        playerAnim.SetFloat("movimentoMag", movMagnitude);
        playerAnim.SetFloat("movimentoX", lastMovement.x);
        playerAnim.SetFloat("movimentoY", lastMovement.y);
    }
}   
