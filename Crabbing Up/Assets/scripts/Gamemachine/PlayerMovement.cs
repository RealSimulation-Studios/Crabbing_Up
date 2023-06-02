using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float force = 0f;

    public Rigidbody rb;
    public bool isJumping;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {   
            rb.AddForce(0,force ,0);
            isJumping = true;
        }

        Vector3 movement = new Vector3(MoveHorizontal * speed, 0, 0);

        transform.Translate(movement);
    
        

    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision other)
    {
        isJumping = false;
    }

}
