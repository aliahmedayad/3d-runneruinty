using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coin, jump, game_over, normal_sound;
    public static AudioClip coinSound,JumpSound,GameoverSound,normalSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        JumpSound = jump;
        coinSound = coin;
        GameoverSound = game_over;
        normalSound = normal_sound;
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
                audioSource.PlayOneShot(coinSound);
                audioSource.volume = 0.8f;
                break;
            case "Jump":
                audioSource.PlayOneShot(JumpSound);
                audioSource.volume = 0.7f; 
                break;
            case "Over":
                audioSource.PlayOneShot(GameoverSound);
                audioSource.volume = 0.7f;
                break;
            case "Normal":
                audioSource.clip = normalSound;
                audioSource.loop = true;
                audioSource.volume = 0.5f;
                audioSource.Play();
                break;
        }
    }
    public static void stopSound()
    {
        audioSource.Stop();
    }
}
