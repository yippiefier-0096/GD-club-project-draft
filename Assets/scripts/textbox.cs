using System;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class textbox : MonoBehaviour
{
    public TMP_Text text_container;
    public String[] content= new String[64];
    private int line_index=0;
    private bool next_line;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text_container.maxVisibleCharacters=0;
        StartCoroutine("Display_start");
        foreach (string i in content)
        {
            print(i);
        }
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
                    GetComponentInParent<playerController>().can_control=true;
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

        var _cur=content[line_index];

        text_container.text=_cur;
        text_container.maxVisibleCharacters=0;
        for(int i=0;i<_cur.Length;i++)
            {
                text_container.maxVisibleCharacters+=1;
                yield return new WaitForSeconds(0.05f);
            }
        next_line=true;
        
    }
}
