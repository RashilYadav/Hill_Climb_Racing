using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin5 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreScript.scoreVal += 5;
            //Play Sound
            Destroy(gameObject);
        }
    }
}
