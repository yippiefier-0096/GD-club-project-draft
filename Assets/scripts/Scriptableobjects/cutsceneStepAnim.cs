using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "cutsceneStepAnim", menuName = "Scriptable Objects/cutsceneStep/cutsceneStepAnim")]
public class cutsceneStepAnim : cutsceneStep
{   
    [Serializable]
    public struct animStep
    {
        public float speed;
        //pixel per second walked
        public GameObject target;
        public UnityEngine.Vector2 displacement;
        public bool parallel;
    }
    public animStep[] step_list;
    public override IEnumerator step()
    {

        yield return new WaitForNextFrameUnit();
        //change this later

    }
}
