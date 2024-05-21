using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractiveLoadLevel : Interactable
{
    [SerializeField] string LevelName;
    public override void InteractionTriggered()
    {
        SceneManager.LoadScene(LevelName);
    }
}
