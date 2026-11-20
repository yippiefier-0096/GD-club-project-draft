using System;
using System.Collections;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mono.Cecil;
using NUnit.Framework;
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
    public bool is_save=false;
    public int interact_index=0;
    public int repeat_mode=0;
    public UnityEvent trigger_event;
    private GameObject text;
    public playerController lock_target;
    public cutsceneInstance cutscene_slot;
    [Serializable]
    public struct StateResource
    {
        public Vector2 state_pos;
        
    }
    public int state_entry;
    public StateResource[] state_reference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       interact_index=0;
       Init_event();
       
    }
    void Retrieve_state()
    {
        int _e=gameManager.loaded_file.objflag[state_entry];
        if ( _e != 0)
        {
            Vector2 _pos= state_reference[_e].state_pos;
            transform.SetPositionAndRotation(transform.position+new Vector3(_pos.x,_pos.y,0),quaternion.identity);
        }
    }
    public void Init_event()
    {
        print("updated");
        trigger_event.RemoveAllListeners();
        if (content.GetLength(0)>0)
        {
            if (content[interact_index] is interactInstancePath _c)
                cur_content=_c.Check_path();
            else
                cur_content=content[interact_index];
            if (cur_content.msg_content is not null)
                trigger_event.AddListener(Push_text);
            
            if (cur_content.item is not null)
                trigger_event.AddListener(Give_item);
            
            if (!cur_content.lock_to_current)
                trigger_event.AddListener(Iterate);
        }
        if (cutscene_slot)
            trigger_event.AddListener(Push_cutscene);
        if (is_save)
            trigger_event.AddListener(gameManager.saveToFile);  
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
        gameManager.Push_text(cur_content);
    }
    public void Push_cutscene()
    {   
        gameManager.Push_cutscene(cutscene_slot);
    }
    public void Give_item()
    {
        print("item");
    }

}



