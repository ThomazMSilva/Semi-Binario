using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private float speed, movMagnitude;
    private Vector2 
        movement,
        lastMovement;

    void Update()
    {
        movement = new(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
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

    private void Start()
    {
        if (LevelManager.CurrentLevel > 0) playerAnim.SetLayerWeight(1, 1);
    }

    void UpdateAnimation()
    {
        playerAnim.SetFloat("movimentoMag", movMagnitude);
        playerAnim.SetFloat("movimentoX", lastMovement.x);
        playerAnim.SetFloat("movimentoY", lastMovement.y);
    }
}   
