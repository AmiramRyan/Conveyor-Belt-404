using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject wheel;
    public float turningSpeed;
    public float dir;
    private bool rotate;
    private float maxAngle = 75f;
    private float minAngle = -75f;
    private void Start()
    {
        rotate = false;
    }

    public void Update()
    {
        //get input
        if (Input.GetButtonDown("right"))
        {
            dir = -1;
            rotate = true;
        }
        else if (Input.GetButtonDown("left"))
        {
            dir = 1;
            rotate = true;
        }

        //rotate
        if (rotate)
        {
            Quaternion wheelRot = wheel.transform.rotation;
            Vector3 wheelRotEuler = wheelRot.eulerAngles;
            float wAngle = WrapAngle(wheelRotEuler.z);
            wheel.transform.Rotate(Vector3.forward, turningSpeed * dir);
            if (wAngle >= maxAngle || wAngle <= minAngle)
            {
                if(wAngle >= maxAngle)
                {
                    wheel.transform.rotation = Quaternion.Euler(new Vector3(wheel.transform.rotation.eulerAngles.x, wheel.transform.rotation.eulerAngles.y, maxAngle - 0.001f));
                }
                else
                {
                    wheel.transform.rotation = Quaternion.Euler(new Vector3(wheel.transform.rotation.eulerAngles.x, wheel.transform.rotation.eulerAngles.y, minAngle + 0.001f));
                }
                rotate = false;
            }
        }
    }

    private float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

}
