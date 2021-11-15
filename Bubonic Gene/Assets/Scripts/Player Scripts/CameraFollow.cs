using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Player Camera
    //public Transform Player;
    public Transform Target;

    public float SmoothSpeed = 0.125f;
    public Vector3 Offset;

    void FixedUpdate ()

    {
        Vector3 desiredPosition = Target.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, SmoothSpeed);
        transform.position = smoothedPosition;
    }

   // void FixedUpdate ()
    //{
     //   transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    //}
    
}

//Elina Salmenranta