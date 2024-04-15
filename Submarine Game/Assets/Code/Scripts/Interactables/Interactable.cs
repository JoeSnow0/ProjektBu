using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //All Interactables have a name
    public string mItemName;
    //And an activation function
    public abstract void InteractionTriggered();
}
