using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin100 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreScript.scoreVal += 100;
            //Play Sound
            SoundScript.PlaySound("coin");
            Destroy(gameObject);
        }
    }
}
