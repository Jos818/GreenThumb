//QuitTrigger.cs by Joseph Panara for Green Thumb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Close the application when the player enters the trigger. Used in the start menu scene
public class QuitTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
