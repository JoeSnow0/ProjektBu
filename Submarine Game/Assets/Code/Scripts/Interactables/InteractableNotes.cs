using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNotes : Interactable
{
    PlayerUIController mPlayerUI;
    public StringReference myText;

    private void Start()
    {
        mPlayerUI = FindObjectOfType<PlayerUIController>();
        mItemName = myText.name;
    }
    public override void InteractionTriggered()
    {
        //visa text
        if (myText != null)
        {
            mPlayerUI.NotesText.text = myText.text;
        }
        else
        {
            mPlayerUI.NotesText.text = "Missing text file";
        }
        mPlayerUI.NotesPanel.gameObject.SetActive(true);
    }

}
