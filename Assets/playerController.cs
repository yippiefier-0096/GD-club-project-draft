using UnityEngine;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{

    public Animator player_anim;
    public Rigidbody2D player_body;
    private Vector2 velocity;
    public int direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_body=GetComponent<Rigidbody2D>();
        player_anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x=Input.GetAxisRaw("Horizontal");
        velocity.y=Input.GetAxisRaw("Vertical");
        velocity=Vector2.Normalize(velocity);
        if (velocity.magnitude!=0)
            direction=(int)(Vector2.Angle(Vector2.up,velocity)/45);
            print(direction);
            player_body.SetRotation((float)direction*45);   
        player_body.linearVelocity=velocity*5;       
    }
    void FixedUpdate()
    {

    }
}
