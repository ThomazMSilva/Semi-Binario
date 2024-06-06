using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D playerRB;
    [SerializeField]
    float
        speed;

    void Update()
    {
        playerRB.velocity = new(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
    }
}
