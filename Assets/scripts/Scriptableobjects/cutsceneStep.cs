using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "cutsceneStep", menuName = "Scriptable Objects/cutsceneStep")]
public abstract class cutsceneStep : ScriptableObject
{   
    public abstract IEnumerator step();
    
    
}   
