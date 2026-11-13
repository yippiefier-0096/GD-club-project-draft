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
        public bool parallel;
    }

    [SerializeField]
    public Dictionary<string, animStep[]> step_list;

    public override IEnumerator step()
    {   
        Dictionary<string,animationTarget> reference=gameManager.List_animatable();
        foreach(KeyValuePair<string,animStep[]> i in step_list )
        {   
            animationTarget _a = reference.GetValueOrDefault(i.Key,null);
            if (_a)
            {
                _a.SetDisplace(i.Value);
            }
        }
        // DG.Tweening.Sequence[] tweenerqueue=new DG.Tweening.Sequence[64];
        // foreach(KeyValuePair<string,animStep[]> i in step_list )
        // {
        //     tweenerqueue.Append(DOTween.Sequence());
        //     foreach (animStep j in i.Value)
        //     {
        //         tweenerqueue.Last().Append(i.Key.transform.DOMove(new Vector3(j.displacement.x,j.displacement.y,0),j.displacement.magnitude/j.speed));
        //     }
        // }
        yield return new WaitUntil(()=>DOTween.PlayingTweens()==null);
        //change this later
    }
}
