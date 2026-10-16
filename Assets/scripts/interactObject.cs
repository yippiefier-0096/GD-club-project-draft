using System;
using System.Collections;
using JetBrains.Annotations;
using Mono.Cecil;
using Unity.Collections;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class interactObject : MonoBehaviour
{
    [Header("Event on Check")]
    public String[] content;
    public UnityEvent trigger_event;
    private GameObject text;
    public playerController lock_target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (content[0]!="")
        {
            
            trigger_event.AddListener(Push_text);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Push_text()
    {   
        lock_target.can_control=false;
        lock_target.player_body.linearVelocity=Vector2.zero;
        text=Resources.Load<GameObject>("prefabs/dialogue");
        var _t=Instantiate<GameObject>(text,Vector3.zero,quaternion.identity);
        _t.GetComponentInChildren<textbox>().content=this.content;
        _t.GetComponent<Canvas>().renderMode=RenderMode.ScreenSpaceOverlay;
        _t.transform.SetParent(lock_target.transform);
    }

}



