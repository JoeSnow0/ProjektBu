using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : Pickup
{
    [Header("Assign this")]
    public Key mKey;
    [SerializeField] MeshRenderer[] KeyDisplay;

    private void Start()
    {
        if (mKey != null)
        {
            foreach (var key in KeyDisplay)
            {
                key.material = mKey.KeyMaterial;
            }
        }
        mItemName = mKey.KeyName;
    }
    public override void InteractionTriggered()
    {
        FindObjectOfType<PlayerInteraction>().AddKey(mKey);
        TriggerStaticEnemy();
        Destroy(gameObject);
    }
}
