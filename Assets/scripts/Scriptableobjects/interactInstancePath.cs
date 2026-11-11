using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;


[CreateAssetMenu(fileName = "interactInstanceChoice", menuName = "Scriptable Objects/interactInstance/Path",order = 1)]
public class interactInstancePath : interactInstance
{
    public interactInstance[] paths;
    public int testkey;
    [Serializable]
    public struct pathcheck
    {
        [Tooltip("The type of flag being checked")]
        public string check_type;
        [Tooltip("Which item of the selected type to check (e.g. story flag #92)")]
        public int check_id;
        [Tooltip("What the value of the checked item should be")]
        public int wanted;
        [Tooltip("which branch this check correspond to")]
        public int index;

    }
    public pathcheck[] criteria;
    public interactInstance Check_path()
    {   
        interactInstance answer=paths[0];
        foreach (pathcheck i in criteria)
        {
            switch (i.check_type)
            {
                case "Item":
                      
                    break;
                case "Test":
                    if (i.check_id == testkey)
                    {
                        answer=paths[i.index];
                    }
                    break;
                default:
                    
                    break;   
            }
            
        }
        return answer;
    }
}
