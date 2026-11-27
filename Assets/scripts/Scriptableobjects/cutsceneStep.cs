using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "cutsceneStep", menuName = "Scriptable Objects/cutsceneStep")]
public abstract class cutsceneStep : interactInstance
{   
    public abstract IEnumerator step();
}   
