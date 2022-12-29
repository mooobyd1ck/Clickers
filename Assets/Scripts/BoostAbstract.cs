using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boosts : MonoBehaviour 
{
    public abstract void Update();
    public abstract void OnMouseDown();
    public abstract void TurnAround();

}
