using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb2d;
    CircleCollider2D circleCollider2D;
    bool isTriggeredWithMagnet = false;
    bool isCollidedWithMagnet = false;
    [SerializeField] PlayerState playerState;
    bool isJumpPressed = false;
    Rope rope;
    PlayerControls playerControls;

    [SerializeField] float normalGravityScale = 8f;
    [SerializeField] float moveSpeed = 500f;
    [SerializeField] float moveSpeedOnRope = 300f;
    [SerializeField] float jumpSpeed = 1200f;
    [SerializeField] float climbSpeed = 400f;
    [SerializeField] float horizontalLossSpeed = 5f;
    [SerializeField] float verticalLossSpeed = 5f;


    public bool isAttachedToRope = false;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        playerControls = new PlayerControls();
    }
    
    private void OnEnable() {
        playerControls.Player.Enable();
    }

    private void OnDisable() {    
        playerControls.Player.Disable();
    }


    void FixedUpdate() {
        GetState();
        Climb();
        Move();
        Jump();
        Gravity();
    }

    void GetState() {
        if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Rope"))) {
            playerState = PlayerState.OnTheRope;
        } else if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            playerState = PlayerState.OnTheGround;
        } else if (isCollidedWithMagnet) { // TODO: change to iscollided
            playerState = PlayerState.OnTheMagnet;
        } else {
            playerState = PlayerState.InTheAir;
        }
    }

    void Move() {
        if (playerState == PlayerState.OnTheGround) {
            MoveOnTheGround();
        } else if (playerState == PlayerState.OnTheMagnet) {
            MoveOnTheMagnet();
        } else if (playerState == PlayerState.OnTheRope) {
            MoveOnTheRope();
        } else {
            MoveInTheAir();
        }
    } 
    
    void MoveOnTheGround() {
        if (isAccelerating()) {
            Decelerate();
        } else {
            rb2d.velocity = new Vector2(moveInput.x * moveSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
        }
    }

    void MoveOnTheMagnet() {
        rb2d.velocity = new Vector2(moveInput.x * moveSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
    }

    void MoveOnTheRope() {
        rb2d.velocity = new Vector2(moveInput.x * moveSpeedOnRope * Time.fixedDeltaTime, rb2d.velocity.y);
    }

    void MoveInTheAir() {
        if (isAccelerating()) {
            Decelerate();
        } else {
            rb2d.velocity = new Vector2(moveInput.x * moveSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
        }
    }

    void Decelerate() {
        if (rb2d.velocity.x > moveSpeed * Time.fixedDeltaTime + 3f) {
            rb2d.velocity -= new Vector2(horizontalLossSpeed, verticalLossSpeed) * Time.fixedDeltaTime;
        } else if (rb2d.velocity.x < -moveSpeed * Time.fixedDeltaTime - 3f) {
            rb2d.velocity -= new Vector2(-horizontalLossSpeed, verticalLossSpeed) * Time.fixedDeltaTime;   
        }
    }

    bool isAccelerating() {
        if (rb2d.velocity.x > moveSpeed * Time.fixedDeltaTime + 3f) {
            return true;
        } else if (rb2d.velocity.x < -moveSpeed * Time.fixedDeltaTime - 3f) {
            return true;
        }

        return false;
    }

    void Jump() {
        if (isJumpPressed) {
            isJumpPressed = false;

            if (playerState == PlayerState.OnTheGround) {
                JumpOnTheGround();
            } else if (playerState == PlayerState.OnTheMagnet) {
                JumpOnTheMagnet();
            } else if (playerState == PlayerState.OnTheRope) {
                JumpOnTheRope();
            } else {
                JumpInTheAir();
            }
        }
    }

    void JumpOnTheGround() {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed * Time.fixedDeltaTime);
    }

    void JumpOnTheMagnet() {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed * Time.fixedDeltaTime);
    }

    void JumpOnTheRope() {
        if (hasHorizontalSpeed()) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed * Time.fixedDeltaTime);
        }
    }

    void JumpInTheAir() {
        // Can't jump again for now
    }

    void Gravity() {
        if (playerState == PlayerState.OnTheGround) {
            rb2d.gravityScale = normalGravityScale;
        } else if (playerState == PlayerState.OnTheMagnet) {
            rb2d.gravityScale = 0f;
        } else if (playerState == PlayerState.OnTheRope) {
            rb2d.gravityScale = 0f;
        } else {
            rb2d.gravityScale = normalGravityScale;
        }
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value) {
        if (value.isPressed) {
            isJumpPressed = true;
        } else {
            isJumpPressed = false;
        }
    }

    bool hasHorizontalSpeed() {
        if (Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon) {
            return true;
        }

        return false;
    }

    void Climb() {
        if (playerState == PlayerState.OnTheRope) {
            ClimbOnTheRope();
        }
    }

    void ClimbOnTheRope() {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && hasHorizontalSpeed()) {
            circleCollider2D.enabled = false;
            Invoke("RestoreCollider", 0.1f);
        }

        rb2d.velocity = new Vector2(rb2d.velocity.x, Time.fixedDeltaTime * climbSpeed * moveInput.y);
    }

    void RestoreCollider() {
        circleCollider2D.enabled = true;
    }

    void SwingRope() {
        if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Rope"))) {
            rb2d.gravityScale = 0f;

            if (isPlayerMovingLeftOrRight()) {
                Rigidbody2D ropeRb2d = rope.GetComponent<Rigidbody2D>();
                ropeRb2d.velocity = new Vector2(moveInput.x * moveSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
            }

        } else {
            rb2d.gravityScale = 8f;

            // if (rope) {
            //     Rigidbody2D ropeRb2d = rope.GetComponent<Rigidbody2D>();
            //     ropeRb2d.velocity = new Vector2(0f, ropeRb2d.velocity.y);
            // }
        }
    }

    bool isPlayerMovingLeftOrRight() {
        if (Keyboard.current.leftArrowKey.isPressed) {
            return true;
        }

        if (Keyboard.current.rightArrowKey.isPressed) {
            return true;
        }

        return false;
    }

    public void SetRope(Rope rope) {
        this.rope = rope;
    }

    public Rope GetRope() {
        return rope;
    }

    public void SetIsTriggeredWithMagnet(bool isTriggered) {
        isTriggeredWithMagnet = isTriggered;
    }

    public bool GetIsTriggeredWithMagnet() {
        return isTriggeredWithMagnet;
    }

    public void SetIsCollidedWithMagnet(bool isCollided) {
        isCollidedWithMagnet = isCollided;
    }

    public bool GetIsCollidedWithMagnet() {
        return isCollidedWithMagnet;
    }
}
