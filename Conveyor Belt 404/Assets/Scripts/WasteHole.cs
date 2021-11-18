using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteHole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ToxBarrle"))
        {
            Destroy(other.gameObject);
        }
    }
}
