using System;
using UnityEngine;

[CreateAssetMenu(fileName = "interactInstance", menuName = "Scriptable Objects/interactInstance")]
public class interactInstance : ScriptableObject
{
    public String[] msg_speaker;
    public String[] msg_content;
    public float[] msg_speed;
    
    public inventoryItem item;
    
}
