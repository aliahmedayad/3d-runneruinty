using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coin, jump, game_over;
    public static AudioClip coinSound,JumpSound,GameoverSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        JumpSound=jump;
        coinSound=coin;
        GameoverSound= game_over;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void playSound(string source)
    {
        switch (source)
        {
            case "Coin":
                audioSource.PlayOneShot(coinSound); break;
            case "Jump":
                 audioSource.PlayOneShot(JumpSound); break;
            case "Over":
                audioSource.PlayOneShot(GameoverSound); break;
        }
    }
}
