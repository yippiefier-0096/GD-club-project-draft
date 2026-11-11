using System;
using UnityEngine;

[CreateAssetMenu(fileName = "interactInstance", menuName = "Scriptable Objects/interactInstance/Base",order = 0)]
public class interactInstance : ScriptableObject
{
    
    public String[] msg_speaker;
    public String[] msg_content;
    public float[] msg_speed;
    public bool lock_to_current=false;
    
    
    public inventoryItem item;
    
}
