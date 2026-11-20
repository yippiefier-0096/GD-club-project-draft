using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class cutsceneStepAssign : cutsceneStep
{
    [Serializable]
    public struct SpawnInfo
    {
        public GameObject prefab;
        public Vector3 spawn_pos;
        public string anim_name;
    }

    public SpawnInfo[] entity_list;
    public override IEnumerator step()
    {
        if (entity_list.GetLength(0)==0)
            yield return new WaitForEndOfFrame();
        foreach (SpawnInfo i in entity_list)
        {
            GameObject _obj=Instantiate(i.prefab,i.spawn_pos,quaternion.identity);
            animationTarget _a=_obj.AddComponent<animationTarget>();
            _a.name_ref=i.anim_name;
        } 
        yield return new WaitForEndOfFrame();
    }
}
