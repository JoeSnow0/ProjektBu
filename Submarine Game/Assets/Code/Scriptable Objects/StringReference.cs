using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "References/TextReference")]
public class StringReference : ScriptableObject
{
    [TextArea(10, 50)]
    public string text;
}
