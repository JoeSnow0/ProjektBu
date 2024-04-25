using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuNavigation : MonoBehaviour
{
    [SerializeField] ButtonTemplate mButtonPrefab;
    string RemoveFront = "Assets/Scenes/";
    string RemoveBack = ".unity";

    private void Start()
    {
        GenerateButtons();
    }
    /// <summary>
    /// This will only work while all the scenes are in the same folder, 
    /// its a temporary fix and not permanent but it makes working with scenes a lot easier!
    /// </summary>
    void GenerateButtons()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string tempText = SceneUtility.GetScenePathByBuildIndex(i);
            print(tempText);
            string[] words = tempText.Split(RemoveFront);
            tempText = words[1];
            print(tempText);
            words = tempText.Split(RemoveBack);
            tempText = words[0];
            print(tempText);
            ButtonTemplate newButton = Instantiate(mButtonPrefab, transform);
            newButton.mLevelName = tempText;
            newButton.mButtonText.text = tempText;
        }
        //foreach (Scene scene in scenes)
        //{
        //    ButtonTemplate newButton = Instantiate(mButtonPrefab, transform);
        //    newButton.mScene = scene;
        //    string tempText = SceneUtility.GetScenePathByBuildIndex(scene.buildIndex);
        //    print(tempText);
        //    newButton.mButtonText.text = "";
        //}
    }
}
