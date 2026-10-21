using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;


[CreateAssetMenu(fileName = "interactInstanceChoice", menuName = "Scriptable Objects/interactInstanceChoice")]
public class interactInstancePath : interactInstance
{
    public interactInstance[] paths;
    public int testkey;
    [Serializable]
    public struct pathcheck
    {
        public string check_type;
        public int check_id;
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
