using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelTimer : ControlPanel
{
    float timerCurrent = 0f;
    [Header("Timer")]
    [Tooltip("Set the amount of time the door remains open")]
    [SerializeField] float timerLength = 0f;
    bool timerOn = false;
    public void TimerReset()
    {
        timerCurrent = 0f;
        timerOn = true;
        TargetToUnlock.myObject.UnlockDoor(true);
        TargetToUnlock.myObject.OpenDoor(true);

    }
    void TimerCount()
    {
        timerCurrent += Time.deltaTime;
    }
    void TimerDone()
    {
        TargetToUnlock.myObject.OpenDoor(false);
        TargetToUnlock.myObject.UnlockDoor(false);
        timerOn = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            TimerCount();
        }
        if(timerOn && timerCurrent >= timerLength)
        {
            TimerDone();
        }
    }
}
