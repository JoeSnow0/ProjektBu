using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlPanelTimer : ControlPanel
{
    [SerializeField] TextMeshPro timerDisplayText;
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
        float time = timerLength - timerCurrent;
        timerDisplayText.text = time.ToString();
    }
    void TimerDone()
    {
        TargetToUnlock.myObject.OpenDoor(false);
        TargetToUnlock.myObject.UnlockDoor(false);
        timerOn = false;
        timerDisplayText.text = "0.00";
    }
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
