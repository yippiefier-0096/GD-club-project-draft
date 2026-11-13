using UnityEngine;
using DG;
using DG.Tweening;
using DG.Tweening.Core;
public class animationTarget : MonoBehaviour
{
    public string name_ref;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDisplace(cutsceneStepAnim.animStep[] steps)
    {
        Vector3 _origin=transform.position;
        Vector3 _target=Vector3.zero;
        DOTween.defaultEaseType=Ease.Linear;
        DG.Tweening.Sequence seq = DOTween.Sequence();
        foreach (cutsceneStepAnim.animStep i in steps)
        {
            
            _target=_origin+new Vector3(i.displacement.x,i.displacement.y,0);
            seq.Append(gameObject.transform.DOMove(_target,i.displacement.magnitude/i.speed));
            _origin=_target;
        }
    }
    public void SetTarget(cutsceneStepAnim.animStep[] steps)
    {
        DOTween.defaultEaseType=Ease.Linear;
        DG.Tweening.Sequence seq = DOTween.Sequence();
        foreach (cutsceneStepAnim.animStep i in steps)
        {
            var _target=new Vector3(i.displacement.x,i.displacement.y,0);
            seq.Append(gameObject.transform.DOMove(_target,i.displacement.magnitude/i.speed));
        }       
    }
}
