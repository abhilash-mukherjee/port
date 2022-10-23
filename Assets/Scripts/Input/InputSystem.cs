using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputSystem : ScriptableObject
{
    
    public abstract void StartInput();
    public abstract float GetInput();
}
