using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericBarrel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private float speed;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ConvBeltRight")) //simulating the conv belt movement
        {
            myRb.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
        }
        else if (other.gameObject.CompareTag("ConvBeltLeft"))
        {
            myRb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
        }
    }
}
