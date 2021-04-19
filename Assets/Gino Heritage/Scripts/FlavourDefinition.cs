using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Flavours 
{
    electronic, 
    muonic,
    tauonic,
    count
}

public class FlavourDefinition : MonoBehaviour
{
    #region Public names
    public Flavours flavour;
    #endregion

    public void SetFlavour(Flavours newFlavour)
    {
        flavour = newFlavour;
    }
}
