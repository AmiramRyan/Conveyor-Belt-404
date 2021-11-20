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
    public Animator btn_anim;
    void Start()
    {
        rotate = false;
        wheel = GameObject.FindWithTag("Wheel");
        btn_anim = GameObject.FindWithTag("Ui_btns").GetComponent<Animator>();
        if (!wheel)
        {
            Debug.LogError("No wheel found in lever controller");
        }
        if (!btn_anim)
        {
            Debug.LogError("No Animator found in lever controller");
        }
    }

    public void Update()
    {
        //get input
        if (Input.GetButtonDown("right"))
        {
            dir = -1;
            rotate = true;
            btn_anim.SetTrigger("right");
        }
        else if (Input.GetButtonDown("left"))
        {
            dir = 1;
            rotate = true;
            btn_anim.SetTrigger("left");
        }
        else if (Input.GetButtonDown("up"))
        {
            dir = 0;
            rotate = true;
            btn_anim.SetTrigger("up");
        }

        //rotate
        if (rotate)
        {
            Quaternion wheelRot = wheel.transform.rotation;
            Vector3 wheelRotEuler = wheelRot.eulerAngles;
            float wAngle = WrapAngle(wheelRotEuler.z);

            if (dir == 0) //return to middle
            {
                if(wAngle > 0.21) //rotate right
                {
                    wheel.transform.Rotate(Vector3.forward, turningSpeed * -1);
                }
                else if (wAngle < -0.21) //rotate left
                {
                    wheel.transform.Rotate(Vector3.forward, turningSpeed * 1);
                }
                else//stop condition the wAngle is 0
                {
                    wheel.transform.rotation = Quaternion.Euler(new Vector3(wheel.transform.rotation.eulerAngles.x, wheel.transform.rotation.eulerAngles.y,0));
                    rotate = false;
                }
            }

            else //go to the side
            {
                wheel.transform.Rotate(Vector3.forward, turningSpeed * dir);
                if (wAngle >= maxAngle || wAngle <= minAngle) //stop condition
                {
                    if (wAngle >= maxAngle)
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
    }

    private float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

}
