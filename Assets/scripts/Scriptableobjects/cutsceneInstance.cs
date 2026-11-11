using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "cutsceneInstance", menuName = "Scriptable Objects/cutsceneInstance")]
public class cutsceneInstance : ScriptableObject
{
    // [Serializable]
    // public struct animStep
    // {
    //     public GameObject target;
    //     public UnityEngine.Vector2 displacement;
        
    // }
    // [Serializable]
    // public struct cutsceneStep
    // {
    //     public int duration;
    //     public interactInstance dialogue;
    //     public animStep[] movement;
    //     public bool parallel;
    // }
    public cutsceneStep[] cutscene_Array;
    
}
