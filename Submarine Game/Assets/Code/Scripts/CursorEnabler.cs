using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorEnabler : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
