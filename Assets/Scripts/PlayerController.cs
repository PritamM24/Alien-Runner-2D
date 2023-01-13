using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;//used for movement on the x axis
    private float moveSpeedStore;
    

    public float speedMul;//speed multiplier

    public float speedAddMilestone;
    private float speedAddMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpforce;// for jumping and can be used to edit the values in editor itself

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJump;
    private bool doubleJump;

    private Rigidbody2D rigidbody;

    public bool grounded;//bool to check true or false
    public LayerMask Layer;// to check the layer also can be edited in editor
    public Transform groundDetector;
    public float groundDetrad;

    //private Collider2D collider;

    private Animator animator;//to access tha animators and animations.

    public GameManager gameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();//get player component.

        //collider = GetComponent<Collider2D>();

        animator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedAddMilestone;

        moveSpeedStore = movespeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedAddMilestoneStore = speedAddMilestone;

        stoppedJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(collider, Layer);

        grounded = Physics2D.OverlapCircle(groundDetector.position, groundDetrad, Layer);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedAddMilestone;
            speedAddMilestone = speedAddMilestone * speedMul;
            movespeed = movespeed * speedMul;
        }

        rigidbody.velocity = new Vector2(movespeed, rigidbody.velocity.y);//for character movement
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpforce);
                stoppedJump = false;
                jumpSound.Play();
            }

            if (!grounded && doubleJump)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpforce);
                jumpTimeCounter = jumpTime;
                stoppedJump = false;
                doubleJump = false;
                jumpSound.Play();
            }
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJump) 
        {
            if (jumpTimeCounter > 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpforce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJump = true;
        }

        if(grounded)
        {
            jumpTimeCounter = jumpTime;
            doubleJump = true;
        }
        animator.SetFloat("Speed", rigidbody.velocity.x);
        animator.SetBool("Grounded",grounded);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            gameManager.RestartGame();
            movespeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedAddMilestone = speedAddMilestoneStore;
            deathSound.Play();
        }
    }
}
