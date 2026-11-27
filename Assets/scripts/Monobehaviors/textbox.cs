using System;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class textbox : MonoBehaviour
{
    public TMP_Text text_container;
    public interactInstance.DialogueSet[] content= new interactInstance.DialogueSet[64];
    private int line_index=0;
    private bool next_line;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text_container.maxVisibleCharacters=0;
        StartCoroutine("Display_start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Z))
        {
            if (next_line)
            { 
                line_index+=1;
                
                if (content.GetLength(0)<=line_index)
                {
                    print("over");
                    gameManager.player_main.GetComponent<playerController>().can_control=true;
                    Destroy(gameObject);                    
                }
                else
                    StartCoroutine("Display_start");
            }
        }
    }

    IEnumerator Display_start() 
    {
        print (line_index);
        next_line=false;

        interactInstance.DialogueSet _cur=content[line_index];
        GameObject _c_play=null;
        if (!_cur.c_step.IsUnityNull())
            _c_play=gameManager.Push_cutscene(_cur.c_step);
        text_container.text=_cur.content;
        text_container.maxVisibleCharacters=0;
        for(int i=0;i<_cur.content.Length;i++)
            {
                text_container.maxVisibleCharacters+=1;
                yield return new WaitForSeconds(0.05f);
            }
        yield return new WaitUntil(() => _c_play.IsUnityNull());
        next_line=true;
        
    }
}
