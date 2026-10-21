using System;
using System.Collections;
using JetBrains.Annotations;
using Mono.Cecil;
using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class interactObject : MonoBehaviour
{
    [Header("Event on Check")]
    public interactInstance[] content;
    public interactInstance cur_content;
    public int interact_index=0;
    public int repeat_mode=0;
    public UnityEvent trigger_event;
    private GameObject text;
    public playerController lock_target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       interact_index=0;
       Init_event();
    }
    void Init_event()
    {
        trigger_event.RemoveAllListeners();
        if (content[interact_index] is interactInstancePath _c)
            cur_content=_c.Check_path();
        else
            cur_content=content[interact_index];
        if (cur_content.msg_content is not null)
        {
            trigger_event.AddListener(Push_text);
        }     
        if (cur_content.item is not null)
        {
            trigger_event.AddListener(Give_item);
        }
        trigger_event.AddListener(Iterate);
    }
    void Iterate()
    {
        interact_index+=1;
        if (interact_index>=content.GetLength(0))
        {
            if (repeat_mode == 0)
                interact_index-=1;
            else if (repeat_mode == 1)
                interact_index=0;
            
        }
        Init_event();
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
        _t.GetComponentInChildren<textbox>().content=cur_content.msg_content;
        _t.GetComponent<Canvas>().renderMode=RenderMode.ScreenSpaceOverlay;
        _t.transform.SetParent(lock_target.transform);
    }
    public void Give_item()
    {
        print("item");
    }

}



