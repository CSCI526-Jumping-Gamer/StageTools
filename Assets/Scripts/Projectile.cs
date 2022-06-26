using UnityEngine;
using UnityEngine.SceneManagement;
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private bool isActive;
    private float lifetime;
    private Rigidbody2D body;
    //  private Animator anim;
    private BoxCollider2D boxCollider;
    public PlayerController playerController;

    private void Awake()
    {
        hit = false;
        body = GetComponent<Rigidbody2D>();
        //   anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        // movement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (hit)
        {
            
            Deactivate();
            //   return;
        }
        else
        {
            float movementSpeed = speed * Time.deltaTime * direction;
            transform.Translate(movementSpeed, 0, 0);
        }
        if (isActive)
        {
            lifetime += Time.deltaTime;
            if (lifetime > 1.0) Deactivate();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        hit = true;
        if (collision.tag.ToString() == "Player")
        {
            Invoke("ReloadScene", 0);
        }
        boxCollider.enabled = false;
        //    anim.SetTrigger("explode");
    }
    public void SetDirection(float _direction)
    {
        isActive = true;
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        /*      float localScaleX = transform.localScale.x;
              if (Mathf.Sign(localScaleX) != _direction)
                  localScaleX = -localScaleX;

              transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);*/
    }

    public void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
