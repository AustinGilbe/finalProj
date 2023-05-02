/*
    This script defines the behavior of a player's movement in a game. 
*/
using UnityEngine;

// The `PlayerMovement` class is defined and inherits from the `MonoBehaviour` class.
public class MoveWASD : MonoBehaviour
{
    /*
        `rb` is a Rigidbody2D component that represents the physical body of the player. `anim` is an Animator component that controls the player's animations. 
        `sprite` is a SpriteRenderer component that renders the player's sprite. `coll` is a BoxCollider2D component that represents the player's hitbox (invisible 
         box used to detect collisions between game objects). `jumpableGround` is a LayerMask that represents the layers of objects that the player can jump on.
    */
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    // Private variables that store the horizontal direction the player is moving (`dirX`), the player's movement speed (`moveSpeed`), and the player's jump force (`jumpForce`).
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    //  Define an enumeration called `MovementState` with the possible values of `idle`, `running`, `jumping`, and `falling`.
    private enum MovementState { idle, running, jumping, falling }

    // Private variable that stores the AudioSource component for the sound effect that plays when the player jumps.
    [SerializeField] private AudioSource jumpSound;

    /*
        Start() is called before the first frame update. This method is called once when the script starts running. It assigns the `rb`, `anim`, `sprite`, and `coll` variables to the
        Rigidbody2D, Animator, SpriteRenderer, and BoxCollider2D components attached to the player object, respectively.
    */
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }


    //  This method is called once per frame. 
    private void Update()
    {
        // Get the horizontal input from the player, sets the velocity of the `rb` Rigidbody2D component based on the `moveSpeed` and `dirX` values. 
        if (Input.GetKeyDown(KeyCode.A))
        {
            dirX = -1f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            dirX = 1f;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            dirX = 0f;
        }
        // The second component 'rb.velocity.y' is preserving the current y-component of the velocity. We are changing the velocity in the x-axis while preserving the velocity in the y-axis.Ho
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        /*
            Check if the player has pressed the jump button (`Input.GetButtonDown("Jump")`) and if they are currently on the ground (`isGrounded()`), plays the jump sound effect 
            and sets the vertical velocity of the `rb` Rigidbody2D component to the `jumpForce` value. It then calls the `AnimationUpdate()` method.
        */
        if (Input.GetButtonDown("Jump") && isGroundedCharacter2())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        AnimationUpdateCharacter2();
    }

    // AnimationUpdate() updates the animation state of the player character. 
    private void AnimationUpdateCharacter2()
    {
        // Declare a variable state of the MovementState enum type, which will store the current state of the player's movement.
        MovementState state;

        // Check the value of dirX, which represents the player's horizontal movement direction.
        // If dirX is greater than 0, it sets state to MovementState.running and sets sprite.flipX to false so that the player's sprite faces right. 
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        // If dirX is less than 0, it does the same thing but sets sprite.flipX to true so that the player's sprite faces left.
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }

        // If dirX is equal to 0, it sets state to MovementState.idle.
        else
        {
            state = MovementState.idle;
        }

        // Next, it checks the player's vertical velocity. If it is greater than 0.1, it sets state to MovementState.jumping, and if it is less than -0.1, it sets state to MovementState.falling.
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        // Finally, it sets the integer value of the state variable to the "state" parameter of the anim Animator component, which controls the player's animations.
        anim.SetInteger("state", (int)state);
    }

    /*    
        isGrounded() is a method that uses the BoxCast() method from the Physics2D class to check if the player is currently touching the ground. It does this by casting a box-shaped ray from the center 
        of the player's coll BoxCollider2D component downward with a length of 0.1 units. If this box collides with any objects in the jumpableGround layer mask, then the player is considered to be on the ground, 
        and the method returns true. Otherwise, it returns false.
    */
    private bool isGroundedCharacter2()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
