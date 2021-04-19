using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingFlavourWithGino : MonoBehaviour
{
    public float fadingFactor = 0.3f;
    
    private OscillatingFlavour playerFlavour = null;
    private Flavours penemyFlavour =  Flavours.count;
    private SpriteRenderer penemyRenderer = null;
    
    void Start()
    {
        playerFlavour = GameObject.FindGameObjectWithTag("Player").GetComponent<OscillatingFlavour>();
        penemyRenderer = GetComponent<SpriteRenderer>();

        if(playerFlavour != null) 
        {
            playerFlavour.OnFlavourChanged += ShadingPenemy;
        }

        penemyFlavour = GetComponent<FlavourDefinition>().flavour;
    }

    private void OnDestroy() 
    {
        if(playerFlavour != null) 
        {
            playerFlavour.OnFlavourChanged -= ShadingPenemy;
        }
    }

    private void ShadingPenemy(Flavours flavour) 
    {
        var newColor = penemyRenderer.material.color;
        newColor.a = (penemyFlavour == flavour) ? 1.0f : fadingFactor;

        penemyRenderer.material.color = newColor;
    }
}
