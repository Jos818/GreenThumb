//MusicManager.cs by Joseph Panara for Green Thumb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Handles background music through different scenes
public class MusicManager : MonoBehaviour
{

    public AudioSource audiosource;
    public GameObject backgroundmusic;
    public AudioSource bmaudio;
    public int currentscene;

    //Maintains the background music GameObject through all the scenes, only destroying it before a copy would be created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentscene = SceneManager.GetActiveScene().buildIndex;
        if (currentscene == 14)
        {
            Destroy(this.gameObject);
        }


    }

    //Changes the background music to the one listed for the scene, otherwise the background music from the prior scene continues without interruption
    void Update()
    {
        backgroundmusic = (GameObject.Find("BackgroundMusic"));
        bmaudio = backgroundmusic.GetComponent<AudioSource>();
        if (audiosource.clip != bmaudio.clip)
        {
            audiosource.Stop();
            audiosource.clip = bmaudio.clip;
            audiosource.Play();
        }
        else if (!bmaudio.clip)
        {
            audiosource.Stop();
        }
    }
}
