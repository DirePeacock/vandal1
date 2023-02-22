using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    public float moveSpeed;
    
    [SerializeField] 
    public float rotationSpeed;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 lastMovedVector;
    [HideInInspector]
    public Vector2 movementDirection;


    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);   
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Movement();
        if (movementDirection != Vector2.zero)
            UpdateRotation();
    }

    void InputManagement()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        
        movementDirection.Normalize();
        if (movementDirection.x != 0)
        {
            lastHorizontalVector = movementDirection.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);    //Last moved X
        }

        if (movementDirection.y != 0)
        {
            lastVerticalVector = movementDirection.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);  //Last moved Y
        }

        if (movementDirection.x != 0 && movementDirection.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);    //While moving
        }
    }
    
    void Movement()
    {
        rb.velocity = new Vector2(movementDirection.x * moveSpeed, movementDirection.y * moveSpeed);
        // rb.velocity = movementDirection * moveSpeed;
    }


    void UpdateRotation()
    {
        return ;
        // Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
    }
}
