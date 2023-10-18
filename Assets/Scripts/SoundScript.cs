using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip ButtonSound, Bone_Crack, StartButtonSound, BGMusic, Vehicle_Car_Engine, fuel, coin, Menu_Click;
    public static AudioSource audiosrc;
    // Start is called before the first frame update
    //void Start()
    //{
    //    audiosrc = GetComponent<AudioSource>();
    //    ButtonSound = Resources.Load<AudioClip>("Button");
    //    StartButtonSound = Resources.Load<AudioClip>("StartButtonSound");
    //    BGMusic = Resources.Load<AudioClip>("BGMusic");
    //}

    void Awake()
    {
        audiosrc = GetComponent<AudioSource>();
        ButtonSound = Resources.Load<AudioClip>("Button");
        StartButtonSound = Resources.Load<AudioClip>("StartButtonSound");
        BGMusic = Resources.Load<AudioClip>("BGMusic");
        Vehicle_Car_Engine = Resources.Load<AudioClip>("Vehicle_Car_Engine");
        Bone_Crack = Resources.Load<AudioClip>("Bone_Crack");
        fuel = Resources.Load<AudioClip>("fuel");
        coin = Resources.Load<AudioClip>("coin");
        Menu_Click = Resources.Load<AudioClip>("Menu_Click");

        // Play the background music on awake and set it to loop
        audiosrc.clip = BGMusic;
        audiosrc.loop = true;
        audiosrc.Play();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Button":
                audiosrc.PlayOneShot(ButtonSound);
                break;
            case "StartButtonSound":
                audiosrc.PlayOneShot(StartButtonSound);
                break;
            case "BGMusic":
                audiosrc.PlayOneShot(BGMusic);
                break;
            case "Vehicle_Car_Engine":
                audiosrc.PlayOneShot(Vehicle_Car_Engine);
                break;
            case "Bone_Crack":
                audiosrc.PlayOneShot(Bone_Crack);
                break;
            case "fuel":
                audiosrc.PlayOneShot(fuel);
                break;
            case "coin":
                audiosrc.PlayOneShot(coin);
                break;
            case "Menu_Click":
                audiosrc.PlayOneShot(Menu_Click);
                break;
        }
    }
}
