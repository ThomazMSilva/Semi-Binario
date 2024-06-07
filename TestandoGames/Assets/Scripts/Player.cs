using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float speed;
    private Vector2 movement;

    void Update()
    {
        movement = new(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
    }

    private void FixedUpdate()
    {
        playerRB.velocity = movement;
    }
}   
