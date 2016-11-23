using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    
    Rigidbody rb;
    Vector3 moveDirection;
    Vector3 playerDirection;
    float hMin = -60f;
    float hMax = 60f;
    float vMin = -25f;
    float vMax = 25f;



    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        HandleMovement(h,v);
	}

    void HandleMovement(float h, float v)
    {
        moveDirection.Set(h, 0f, v);
        moveDirection = moveDirection.normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + moveDirection);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, hMin, hMax), 0f, Mathf.Clamp(transform.position.z, vMin, vMax));
        
    }
}
