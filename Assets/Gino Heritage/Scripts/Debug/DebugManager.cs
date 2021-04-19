using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public DebugDB flags;

    public bool isInGodMode {get { return flags != null ? flags.GodMode : false;}}
}
