//TimelinePauser.cs by Joseph Panara for Green Thumb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interacts with the TimelineController script. When the object is enabled, the timeline pauses
public class TimelinePauser : MonoBehaviour
{
    public TimelineController timelinecontroller;

    void OnEnable()
    { 
        timelinecontroller.Pause();
    }
}
