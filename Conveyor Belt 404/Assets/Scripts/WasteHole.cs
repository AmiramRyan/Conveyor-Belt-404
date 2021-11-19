using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteHole : MonoBehaviour
{
    public ScoreManager ScoreManager;
    public string acceptedTag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(acceptedTag))
        {
            //add score
            ScoreManager.AddScore(ScoreManager.correctBarrelValue);
        }
        else
        {
            //decrease score and increase strikes
            ScoreManager.AddScore(ScoreManager.wrongBarrelValue);
        }
        Destroy(other.gameObject);
    }
}
