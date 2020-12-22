using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class objectMover : MonoBehaviour
{
    [SerializeField] private bool isMouseDown = false;
    [SerializeField] private float downForce = 5;


    [SerializeField]private bool isGrounded = false;
    private Vector3 mOffset;
    private float mZCoord;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
            isGrounded = false;
        }
    }
    private void OnMouseDown()
    {
        isMouseDown = true;
        rb.useGravity = false;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    private void OnMouseUp()
    {
        isMouseDown = false;
        rb.isKinematic = false;
        rb.useGravity = true;

        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * downForce, ForceMode.Impulse);
            rb.AddForce(Vector3.forward * downForce, ForceMode.Impulse);
        }
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen

        mousePoint.z = mZCoord;
        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("placingHolder") || collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
}
