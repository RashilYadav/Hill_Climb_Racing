using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin500 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreScript.scoreVal += 500;
            //Play Sound
            SoundScript.PlaySound("coin");
            Destroy(gameObject);
        }
    }
}
