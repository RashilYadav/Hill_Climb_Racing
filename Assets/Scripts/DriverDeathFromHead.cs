using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverDeathFromHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(Died());
        }

        IEnumerator Died()
        {
            SoundScript.PlaySound("Bone_Crack");
            yield return new WaitForSeconds(2f);
           // SoundScript.audiosrc.Stop();
            GameManager.instance.GameOver();
        }
    }
}
