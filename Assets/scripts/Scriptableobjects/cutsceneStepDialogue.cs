using System.Collections;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "cutsceneStep", menuName = "Scriptable Objects/cutsceneStep/cutsceneStepDialogue")]
public class cutsceneStepDialogue : cutsceneStep
{
    public interactInstance dialogue;
    public override IEnumerator step()
    {
        playerController _target= gameManager.player_main.GetComponent<playerController>();
        _target.can_control=false;
        _target.player_body.linearVelocity=Vector2.zero;
        var text=Resources.Load<GameObject>("prefabs/dialogue");
        GameObject _t=Instantiate(text,Vector3.zero,quaternion.identity);
        _t.GetComponentInChildren<textbox>().content=dialogue.msg_content;
        _t.GetComponent<Canvas>().renderMode=RenderMode.ScreenSpaceOverlay;
        _t.transform.SetParent(_target.transform); 
        yield return new WaitUntil(()=>_t==null);
    }
    
}
