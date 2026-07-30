using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
         int numofMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numofMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
