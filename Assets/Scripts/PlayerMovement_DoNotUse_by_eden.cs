using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb2d;
    CircleCollider2D circleCollider2D;
    Magnet magnet;
    AcceleratingTrail acceleratingTrail;
    float normalGravityScale = 8f;
    public bool isTriggeredByMagnet = false;
    bool isCollidedByMagnet = false;

    PlayerControls controls;

    [SerializeField] float moveSpeed = 500f;
    [SerializeField] float moveSpeedWhileClimbing = 300f;
    [SerializeField] float jumpSpeed = 1200f;
    [SerializeField] float jumpSpeedWhileClimbing = 1000f;
    [SerializeField] float horizontalLossSpeed = 5f;
    [SerializeField] float verticalLossSpeed = 5f;

    [SerializeField] float climbSpeed = 400f;
    
    public bool isLeftMagnet = false;
    [SerializeField] float magnetCollidedJumpMultiplier = 1.4f;
    [SerializeField] float magnetNonCollidedJumpMultiplier = 1.2f;
    Rope rope;

    public bool isAttachedToRope = false;


    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        controls = new PlayerControls();
        // controls.Player.Magnetic.performed += ctx => SendMessage("111");
        controls.Player.Magnetic.performed += ctx => SetIsTriggeredByMagnet(true);
        controls.Player.Magnetic.canceled += ctx => SetIsTriggeredByMagnet(false);

    }



    private void Start() {
    }

    void FixedUpdate()
    {
        Run();
        ClimbRope();
        // SwingRope();
        Gravity();
        // DetectMagnetic();
    }

    void Gravity() {
        if (isClimbRopeAvailable()) {
            rb2d.gravityScale = 0f;
        } else if (isCollidedByMagnet) {
            // rb2d.gravityScale = 0f;
        } else {
            rb2d.gravityScale = normalGravityScale;
        }
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value) {
        if (isJumpAvailable()) {
            if (value.isPressed) {
                if (isTriggeredByMagnet) {
                    if (isCollidedByMagnet) {
                        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed * magnetCollidedJumpMultiplier * Time.fixedDeltaTime);
                        // magnet.ExitMagnet();
                    } else {
                        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed * magnetNonCollidedJumpMultiplier * Time.fixedDeltaTime);
                    }
                } else {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed * Time.fixedDeltaTime);
                }
            }
        }
    }
    void DetectMagnetic() {
        if(Keyboard.current.lKey.wasPressedThisFrame) {
            SetIsTriggeredByMagnet(true);
            Debug.Log("1");
        } 
        if(Keyboard.current.lKey.wasReleasedThisFrame){
            SetIsTriggeredByMagnet(false);
            Debug.Log("2");
        }
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {    
        controls.Player.Disable();
    }

    bool isJumpAvailable() {
        if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            return true;
        }

        if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Rope")) && hasHorizontalSpeed()) {
            return true;
        }

        if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Magnet"))) {
            if (isCollidedByMagnet) {
                return true;
            }
        }

        return false;                
    }

    bool hasHorizontalSpeed() {
        if (Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon) {
            return true;
        }

        return false;
    }

    void Run() {
            if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Rope"))) {
                rb2d.velocity = new Vector2(moveInput.x * moveSpeedWhileClimbing * Time.fixedDeltaTime, rb2d.velocity.y);
            } else {
                if (rb2d.velocity.x > moveSpeed * Time.fixedDeltaTime + 3f) {
                    rb2d.velocity -= new Vector2(horizontalLossSpeed, verticalLossSpeed) * Time.fixedDeltaTime;
                } else if (rb2d.velocity.x < -moveSpeed * Time.fixedDeltaTime - 3f) {
                    rb2d.velocity -= new Vector2(-horizontalLossSpeed, verticalLossSpeed) * Time.fixedDeltaTime;   
                } else {
                    rb2d.velocity = new Vector2(moveInput.x * moveSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
                }
            }
    }

    void ClimbRope() {
        if (isClimbRopeAvailable()) {
            if (Keyboard.current.spaceKey.isPressed) {
                return;
            }
            if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Rope")) && !isPlayerMovingLeftOrRight()) {
                Vector2 ropePivotDirection = (rope.transform.parent.position - transform.position).normalized;
                rb2d.velocity = ropePivotDirection * Time.fixedDeltaTime * climbSpeed * moveInput.y;
            }
        }
    }

    bool isClimbRopeAvailable() {
        if (circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Rope"))) {
            return true;
        }

        return false;
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

    public void SetMagnet(Magnet magnet) {
        this.magnet = magnet;
    }

    public void SetRope(Rope rope) {
        this.rope = rope;
    }

    public Rope GetRope() {
        return rope;
    }

    public void SetIsTriggeredByMagnet(bool isTriggered) {
        isTriggeredByMagnet = isTriggered;
    }

    public bool GetIsTriggeredByMagnet() {
        return isTriggeredByMagnet;
    }

    public void SetIsCollidedByMagnet(bool isCollided) {
        isCollidedByMagnet = isCollided;
    }

    public bool GetIsCollidedByMagnet() {
        return isCollidedByMagnet;
    }
}
