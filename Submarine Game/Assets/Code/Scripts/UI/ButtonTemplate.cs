using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTemplate : MonoBehaviour
{
    public Button mButton;
    public Text mButtonText;
    public string mLevelName;

    private void Start()
    {
        mButton = GetComponent<Button>();
    }

    public void loadScene()
    {
        SceneManager.LoadScene(mLevelName);
    }
}
