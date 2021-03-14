using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake() 
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length; // The Singleton pattern / destroying the music player so the music does not restart when the player dies.
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
