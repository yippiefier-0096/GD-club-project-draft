using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class cutscenePlayer : MonoBehaviour
{   

    public cutsceneInstance cutscene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Play_cutscene()
    {
        print ("playing");
        playerController _target= gameManager.player_main.GetComponent<playerController>();
        _target.can_control=false;
        _target.player_body.linearVelocity=Vector2.zero;
        
        foreach (cutsceneStep i in cutscene.cutscene_Array)
        {
            
            yield return i.step();
        }
        _target.can_control=true;
        Destroy(gameObject);
    }
    // public IEnumerator C_step(cutsceneStep cur)
    // {
    //     if (cur.dialogue)
    //     {
    //         playerController _target= gameManager.player_main.GetComponent<playerController>();
    //         _target.can_control=false;
    //         _target.player_body.linearVelocity=Vector2.zero;
    //         var text=Resources.Load<GameObject>("prefabs/dialogue");
    //         GameObject _t=Instantiate(text,Vector3.zero,quaternion.identity);
    //         _t.GetComponentInChildren<textbox>().content=cur.dialogue.msg_content;
    //         _t.GetComponent<Canvas>().renderMode=RenderMode.ScreenSpaceOverlay;
    //         _t.transform.SetParent(_target.transform); 
    //         yield return new WaitUntil(()=>_t==null);
    //     }
    //     if (cur.movement.GetLength(0)!=0)
    //     {
    //         foreach (cutsceneInstance.animStep i in cur.movement)
    //         {
                
    //         }
    //     }
    //}
}
