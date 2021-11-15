using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{

    public CharacterController Controller;

    public float Speed = 6f;

    public float TurnSmoothTime = 0.1f;
    float TurnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnSmoothTime, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);


            Controller.Move(direction * Speed * Time.deltaTime);
        }
    }
}
