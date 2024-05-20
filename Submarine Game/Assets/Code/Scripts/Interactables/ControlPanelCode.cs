using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ControlPanelCode : ControlPanel
{
    [SerializeField] TextMeshPro panelText;
    public string CorrectCode = "11";
    List<char> enteredCode = new List<char>();
    public void AddLetter(char letter)
    {
        if (!panelDone)
        {
            enteredCode.Add(letter);
            if (enteredCode.Count > CorrectCode.Length)
            {
                enteredCode.Clear();
                enteredCode.Add(letter);
                panelText.color = Color.white;

            }
            StringBuilder number = new StringBuilder();
            foreach (char c in enteredCode)
            {

                number.Append(c);
                Debug.Log(number);
            }
            panelText.text = number.ToString();
            if (enteredCode.Count == CorrectCode.Length)
            {
                CheckCodeCorrect(number);
            }
        }

    }
    private void CheckCodeCorrect(StringBuilder number)
    {

        Debug.Log("Entered Code: " + number + " CorrectCode:" + CorrectCode);
        if (number.ToString() == CorrectCode)
        {
            Correct();
        }
        else
        {
            Wrong();
        }
    }
    private void Correct()
    {
        panelDone = true;
        panelText.color = Color.green;
        if (TargetToUnlock != null)
        {
            TargetToUnlock.myObject.UnlockDoor(true);
        }
        else
        {
            Debug.Log("Missing target object, assign in editor");
        }
    }
    private void Wrong()
    {
        panelText.color = Color.red;
        mAudioManager.PlaySound(0, mAudioSource, false);
        if (TargetToUnlock != null)
        {
            TargetToUnlock.myObject.UnlockDoor(false);
        }
        else
        {
            Debug.Log("Missing target object, assign in editor");
        }
    }
}
