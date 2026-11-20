using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "cutsceneStepAnim", menuName = "Scriptable Objects/cutsceneStep/cutsceneStepAnim")]
public class cutsceneStepAnim : cutsceneStep
{   
    [Serializable]
    public struct animStep
    {
        public float speed;
        //pixel per second walked
        public UnityEngine.Vector2 displacement;
        public bool direct_target;
        public float wait_duration;
    }

    [SerializeField]
    public Dictionary<string, animStep[]> step_list;

    public override IEnumerator step()
    {   
        Dictionary<string,animationTarget[]> reference=gameManager.List_animatable();
        foreach(KeyValuePair<string,animStep[]> i in step_list )
        {   
            animationTarget[] _a = reference.GetValueOrDefault(i.Key,null);
            if (_a.GetLength(0)!=0)
            {
                foreach(animationTarget j in _a)
                    j.SetDisplace(i.Value);
            }
        }
        yield return new WaitUntil(()=>DOTween.PlayingTweens()==null);
    }
}
