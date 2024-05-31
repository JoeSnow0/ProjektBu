using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] Image sanityEffect;
    [SerializeField] Slider sanitySlider;
    PlayerSanity mSanity;
    [SerializeField] FloatReference mCurrentSanity;
    public TextMeshProUGUI interactableHUDText;
    public TextMeshProUGUI NotesText;
    public Image NotesPanel;
    public Image InteractablePanel;
    private void Start()
    {
        mSanity = FindObjectOfType<PlayerSanity>();
    }
    void Update()
    {
        if (mSanity.BeingDrained)
        {
            sanitySlider.value = mCurrentSanity.value;
            sanityEffect.gameObject.SetActive(true);

        }
        if (!mSanity.BeingDrained)
        {
            sanitySlider.value = mCurrentSanity.value;
            sanityEffect.gameObject.SetActive(false);

        }
    }
    
}
