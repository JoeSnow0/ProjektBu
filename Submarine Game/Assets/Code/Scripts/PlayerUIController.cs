using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] Slider sanitySlider;
    [SerializeField] FloatReference mCurrentSanity;
    public TextMeshProUGUI interactableHUDText;
    public TextMeshProUGUI NotesText;
    public Image NotesPanel;
    public Image InteractablePanel;

    void Update()
    {
        sanitySlider.value = mCurrentSanity.value;
    }
}
