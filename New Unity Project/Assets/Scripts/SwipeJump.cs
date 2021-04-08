using UnityEngine;

public class SwipeJump : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private Rigidbody2D rb;
    private CapsuleCollider2D colider;
    private SpriteRenderer sprite;
    public GameObject Pr;
    public GameObject gameOver;
    public GameObject win;
    public GameObject Effect;
    public GameObject Boss;
    private float jumpforce = 5f;
    private float fallMultiplier = 1.5f;
    private bool jumpallowed = false;
    private bool tap = false;
    private bool duck = false;
    private bool timerReached = true;
    private float Absx;
    private float Absy;
    private float timer = 0;
    public float speed = 6;
    public int health = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        SwipeCheck();
        if (health <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (gameObject.transform.position.x! <= -7)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Boss.active == false && gameObject.transform.position.x! <= 15)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (gameObject.transform.position.x >= 14)
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown("space"))
        {
            tap = true;
        }
        if (Input.GetKeyDown("up"))
        {
            jumpallowed = true;
        }
        if (Input.GetKeyDown("down"))
        {
            duck = true;
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        JumpIfAllowed();
        DuckIfAllowed();
        Shoot();
    }

    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            var Absx = Mathf.Abs(startTouchPosition.x - endTouchPosition.x);
            var Absy = Mathf.Abs(startTouchPosition.y - endTouchPosition.y);

            if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0 && Absy > 180)
            {
                jumpallowed = true;
            }
            if (endTouchPosition == startTouchPosition && Absx < 180 && Absy < 180)
            {
                tap = true;
            }
            if (endTouchPosition.x > startTouchPosition.x && Absx > 180 && Absy < 180)
            {
                tap = true;
            }
            if (endTouchPosition.y < startTouchPosition.y && rb.velocity.y == 0 && Absy > 180)
            {
                duck = true;
                Instantiate(Effect, transform.position, Quaternion.identity);
            } 
        }
    }

    private void JumpIfAllowed()
    {
        if (jumpallowed)
        {
            rb.velocity = Vector2.up * jumpforce;
            jumpallowed = false;
        }
    }

    private void Shoot()
    {
        if (tap)
        {
            Instantiate(Pr, transform.position, Quaternion.identity);
            tap = false;
        }
    }

    private void DuckIfAllowed()
    {
        if (duck == true)
        {
            colider.size = new Vector2(colider.size.x, 1.259054f);
            colider.offset = new Vector2(colider.offset.x, -0.214803f);
            sprite.enabled = false;
            timerReached = false;
            timer += Time.deltaTime;
            if (!timerReached && timer > 0.75)
            {
                Duck();
                timer = 0;
                timerReached = true;
            }
        }
    }

    private void Duck()
    {
        colider.size = new Vector2(colider.size.x, 1.922164f);
        colider.offset = new Vector2(colider.offset.x, 0.1167515f);
        sprite.enabled = true;
        duck = false;
        Instantiate(Effect, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}