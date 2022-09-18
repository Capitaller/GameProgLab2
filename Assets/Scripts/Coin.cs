using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private ScoreManager sm;
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        sm = FindObjectOfType<ScoreManager>();
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            sm.ScoreCount();
        }
    }
}
