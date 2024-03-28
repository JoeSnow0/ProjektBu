using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PickupItems/Key")]
public class Key : ScriptableObject
{
    public string KeyName;
    public bool aquiredOrRequired;
}
