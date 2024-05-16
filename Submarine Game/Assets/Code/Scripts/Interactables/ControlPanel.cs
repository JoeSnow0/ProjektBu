using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ControlPanel : MonoBehaviour
{
    [SerializeField] AudioManager mAudioManager;
    [SerializeField] AudioSource mAudioSource;
    [SerializeField] TextMeshPro panelText;
    [SerializeField] string CorrectCode = "1113";
    List<char> enteredCode = new List<char>();
    int codeLength;
    [SerializeField] bool panelDone = false;
    private void Start()
    {
        codeLength = CorrectCode.Length; 
        mAudioManager = FindObjectOfType<AudioManager>();
        mAudioSource = GetComponent<AudioSource>();
    }
    public void AddLetter(char letter)
    {
        if(!panelDone)
        {
            enteredCode.Add(letter);
            if(enteredCode.Count > codeLength)
            {
                enteredCode.Clear();
                enteredCode.Add(letter);
                panelText.color = Color.white;

            }
            //Debug.Log(letter);
            //string number = ""; 
            StringBuilder number = new StringBuilder();
            foreach (char c in enteredCode)
            {
                
                number.Append(c);
                Debug.Log(number);
            }
            panelText.text = number.ToString();
            if (enteredCode.Count == codeLength)
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
    }
    private void Wrong()
    {
        panelText.color = Color.red;
        mAudioManager.PlaySound(0, mAudioSource, false);
    }
    public bool GetComplete()
    {
        return panelDone;
    }
}
