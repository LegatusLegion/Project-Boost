using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float mainRotationThrust= 100f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputThrust();
        InputRotation();
    }

    void InputThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up *  mainThrust * Time.deltaTime);
        }
            
    }

    void InputRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(mainRotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-mainRotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so physic can rotate
    }
}
