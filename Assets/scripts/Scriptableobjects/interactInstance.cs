using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "interactInstance", menuName = "Scriptable Objects/interactInstance/Base",order = 0)]
public class interactInstance : ScriptableObject
{
    [Serializable]public struct DialogueSet
    {
        public string content;
        public string speaker;
        public cutsceneStep c_step;
        public DialogueSetting arguments;
    }

    public DialogueSet[] msg;
    
    public bool lock_to_current=false;
    
    
    public inventoryItem item;
    
}
[Serializable]public class DialogueSetting
{
    public float speed;
    
}
