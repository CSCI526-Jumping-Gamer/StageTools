using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb2d;
    CircleCollider2D circleCollider2D;
    BoxCollider2D boxCollider2d;
    bool isTriggeredWithMagnet = false;
    [SerializeField] bool isCollidedWithMagnet = false;
    bool isMagnetized = false;
    bool isHoldingRope = false;
    [SerializeField] PlayerState playerState;
    bool isJumpPressed = false;
    Rope rope;
    PlayerControls playerControls;
    PlayerInput playerInput;

    [SerializeField] float normalGravityScale = 8f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float moveSpeedOnRope = 6f;
    [SerializeField] float swingSpeed = 10f;
    [SerializeField] float jumpSpeed = 24f;
    [SerializeField] float climbSpeed = 8f;
    [SerializeField] float horizontalLossSpeed = 40f;
    [SerializeField] float verticalLossSpeed = 40f;
    // [SerializeField] float maxDistance = 10f;

    private void Awake() {
        // rb2d = GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        // boxCollider2d = GetComponent<BoxCollider2D>();
        boxCollider2d = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
        playerControls.Player.Magnetize.performed += ctx => {
            isMagnetized = true;
        };

        playerControls.Player.Magnetize.canceled += ctx => {
            isMagnetized = false;
        };

        playerControls.Player.HoldRope.performed += ctx => {
            isHoldingRope = true;
        };

        playerControls.Player.HoldRope.canceled += ctx => {
            isHoldingRope = false;
        };
    }
    
    public void OnEnable() {
        playerControls.Player.Enable();
    }

    public void OnDisable() {
        playerControls.Player.Disable();
    }

    public void DisablePlayerInput() {
        playerInput.DeactivateInput();
    }

    public void EnablePlayerInputWithDelay(float delay) {
        Invoke("EnablePlayerInput", delay);
    }

    public void EnablePlayerInput() {
        playerInput.ActivateInput();
    }

    void FixedUpdate() {
        GetState();
        Climb();
        Move();
        Jump();
        Gravity();
    }
    
    private void LateUpdate() {
        circleCollider2D.enabled = true;
    }

    void GetState() {
        if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Rope"))) {
            if (!Keyboard.current.spaceKey.isPressed) {
                if (isMoveUpOrDownPressed()) {
                    playerState = PlayerState.OnTheRope;
                }
            }
            
            if (isHoldingRope) {
                playerState = PlayerState.OnTheRope;
            }
        } else if (boxCollider2d.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            playerState = PlayerState.OnTheGround;
        } else if (isCollidedWithMagnet) { // TODO: change to iscollided
            if (isMagnetized) {
                playerState = PlayerState.OnTheMagnet;
            } else if (boxCollider2d.IsTouchingLayers(LayerMask.GetMask("Magnet"))) {
                playerState = PlayerState.OnTheGround;
            } else {
                playerState = PlayerState.InTheAir;
            }
        } else {
            playerState = PlayerState.InTheAir;
        }
    }

    bool isMoveUpOrDownPressed() {
        if (Keyboard.current.upArrowKey.isPressed) {
            return true;
        }

        if (Keyboard.current.wKey.isPressed) {
            return true;
        }

        if (Keyboard.current.downArrowKey.isPressed) {
            return true;
        }

        if (Keyboard.current.sKey.isPressed) {
            return true;
        }

        return false;
    }

    bool isMoveLeftOrRightPressed() {
        if (Keyboard.current.leftArrowKey.isPressed) {
            return true;
        }

        if (Keyboard.current.aKey.isPressed) {
            return true;
        }

        if (Keyboard.current.rightArrowKey.isPressed) {
            return true;
        }

        if (Keyboard.current.dKey.isPressed) {
            return true;
        }

        return false;
    }

    void Move() {
        if (playerState == PlayerState.OnTheGround) {
            MoveOnTheGround();
        } else if (playerState == PlayerState.OnTheMagnet) {
            MoveOnTheMagnet();
        } else if (playerState == PlayerState.OnTheRope) {
            if (!isHoldingRope) {
                MoveOnTheRope();
            } else {
                if (rope) {
                    rb2d.velocity = new Vector2(0f, 0f);
                    Rigidbody2D ropeRb2d = rope.GetComponent<Rigidbody2D>();

                    if (moveInput.x != 0) {
                        // ropeRb2d.velocity = new Vector2(swingSpeed * moveInput.x, ropeRb2d.velocity.y);
                        ropeRb2d.AddForce(new Vector2(swingSpeed * moveInput.x, 0f), ForceMode2D.Force);
                    }
                }
            }
        } else {
            MoveInTheAir();
        }
    } 
    
    void MoveOnTheGround() {
        if (isAccelerating()) {
            Decelerate();
        } else {
            rb2d.velocity = new Vector2(moveInput.x * moveSpeed, rb2d.velocity.y);
        }
    }

    void MoveOnTheMagnet() {
        rb2d.velocity = new Vector2(moveInput.x * moveSpeed, rb2d.velocity.y);
    }

    void MoveOnTheRope() {
        rb2d.velocity = new Vector2(moveInput.x * moveSpeedOnRope, rb2d.velocity.y);
    }

    void MoveInTheAir() {
        if (isAccelerating()) {
            Decelerate();
        } else {
            rb2d.velocity = new Vector2(moveInput.x * moveSpeed, rb2d.velocity.y);
        }
    }

    void Decelerate() {
        if (rb2d.velocity.x > moveSpeed + 3f) {
            rb2d.velocity -= new Vector2(horizontalLossSpeed, verticalLossSpeed) * Time.fixedDeltaTime;
        } else if (rb2d.velocity.x < -moveSpeed - 3f) {
            rb2d.velocity -= new Vector2(-horizontalLossSpeed, verticalLossSpeed) * Time.fixedDeltaTime;   
        }
    }

    bool isAccelerating() {
        if (rb2d.velocity.x > moveSpeed + 3f) {
            return true;
        } else if (rb2d.velocity.x < -moveSpeed - 3f) {
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
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
    }

    void JumpOnTheMagnet() {
        if (isMagnetized) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
    }

    void JumpOnTheRope() {
        circleCollider2D.enabled = false;
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
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
        // Vector2 ropePivotDirection = (rope.transform.parent.position - transform.position).normalized;
        // rb2d.velocity = ropePivotDirection * climbSpeed * moveInput.y;
        rb2d.velocity = new Vector2(rb2d.velocity.x, climbSpeed * moveInput.y);
    }

    void SwingRope() {
        if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Rope"))) {
            rb2d.gravityScale = 0f;

            if (isPlayerMovingLeftOrRight()) {
                Rigidbody2D ropeRb2d = rope.GetComponent<Rigidbody2D>();
                ropeRb2d.velocity = new Vector2(moveInput.x * moveSpeed, rb2d.velocity.y);
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

    public bool GetIsMagnetized() {
        return isMagnetized;
    }

    public bool GetIsHoldingRope() {
        return isHoldingRope;
    }
    // private void OnDrawGizmosSelected()
    // {
    //         Gizmos.color = Color.green;
    //         Gizmos.DrawWireSphere(transform.position, maxDistance);
        
    // }
}
