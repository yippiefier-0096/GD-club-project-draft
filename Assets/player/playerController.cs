using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;
using UnityPipeline.Microsoft.CodeAnalysis.CSharp.Syntax;

public class playerController : MonoBehaviour
{
    
    public Animator player_anim;
    public Rigidbody2D player_body;
    public SpriteRenderer notifier;
    public CircleCollider2D notice_radius;
    private Vector2 velocity;
    private int direction;
    public bool can_control=true;
    private List<Collider2D> collision_result=new List<Collider2D>();
    private Collider2D interact_target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_body=GetComponent<Rigidbody2D>();
        player_anim=GetComponent<Animator>();
        notice_radius=GetComponent<CircleCollider2D>();
        notifier.enabled=false;
        
    }

    // Update is called once per frame
    void Update()
    {   if (!can_control)
            return;
        velocity.x=Input.GetAxisRaw("Horizontal");
        velocity.y=Input.GetAxisRaw("Vertical");
        velocity=Vector2.Normalize(velocity);
        if (velocity.magnitude!=0)
            direction=(int)(Vector2.Angle(Vector2.up,velocity)/45);
            player_anim.SetInteger("Direction",direction);
        player_body.linearVelocity=velocity*5;             
        
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            if (!interact_target)
                {
                    print("nothing to look at here");
                }
            else if (interact_target.GetComponent<interactObject>())
                {
                    var _i=interact_target.GetComponent<interactObject>();
                    _i.lock_target=this;
                    _i.trigger_event.Invoke();
                }
                    
            else
                {
                    print("nothing interesting");
                }
            
            
        }
    }
    void FixedUpdate()
    {
    }
    bool Notice_check()
    {
        notice_radius.Overlap(ContactFilter2D.noFilter,collision_result); 
        foreach (Collider2D i in collision_result)
        {
            if (i.CompareTag("interactable"))
            {
                interact_target=i;
                return true;
            }
                
        }
        interact_target=null;
        return false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        notifier.enabled=Notice_check();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        notifier.enabled=Notice_check();
    }
}
