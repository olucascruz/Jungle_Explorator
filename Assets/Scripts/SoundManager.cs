using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip Damage, fireball, sword;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        Damage = Resources.Load<AudioClip>("Damage");
        fireball = Resources.Load<AudioClip>("fireball");
        sword = Resources.Load<AudioClip>("sword");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip) 
        {
        case "fireball":
            audioSrc.PlayOneShot (fireball);
            break;
        case "Damage":
            audioSrc.PlayOneShot (Damage);
            break;
        case "sword":
            audioSrc.PlayOneShot (sword);
            break;
        }
    }
}