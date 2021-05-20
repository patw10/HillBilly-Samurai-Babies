using UnityEngine;

public class Control : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private Rigidbody2D rb;
    private CapsuleCollider2D colider;
    private SpriteRenderer sprite;
    public GameObject Pr;
    public GameObject Effect;
    public GameObject Boss;
    public GameObject Spawn;
    private Boss boss;
    private float jumpforce = 5f;
    private float fallMultiplier = 1.5f;
    private bool timerReached = true;
    private float DuckCooldown = 0;
    private float TapCooldown = 0;
    private float Absx;
    private float Absy;
    private float timer = 0;
    public float speed = 6;
    public int health = 1;
    public bool tap = false;
    public bool up = false;
    public bool Tap, swipeRight, swipeUp, swipeDown, swipeLeft;
    public bool isDraging;
    public Vector2 startTouch, swipeDelta;

    private void Start()
    {
        boss = Boss.GetComponent<Boss>();
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            tap = true;
        }
        if (Input.GetKeyDown("up"))
        {
            up = true;
        }
        if (Input.GetKeyDown("down"))
        {
            swipeDown = true;
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
        Swipe();
        TapCheck();
        DuckCooldown += Time.deltaTime;
        TapCooldown += Time.deltaTime;
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (gameObject.transform.position.x !<= -7)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (boss.Bosshealth <= 0 && gameObject.transform.position.x! <= 15)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        JumpIfAllowed();
        DuckIfAllowed();
        Shoot();
    }
    private void TapCheck()
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

            if (endTouchPosition == startTouchPosition && Absx < 180 && Absy < 180)
            {
                Tap = true;
            }
        }
    }
    private void Swipe()
    {
        Tap = swipeRight = swipeUp = false;

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
        }

        if (swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0 && TapCooldown > 0.5f)
                {
                    swipeRight = true;
                }
                else
                {
                    swipeLeft = true;
                }
            }
            else
            {
                if (y < 0 && DuckCooldown > 0.75f)
                {
                    swipeDown = true;
                    Instantiate(Effect, transform.position, Quaternion.identity);
                }
                else if (y > 0)
                {
                    swipeUp = true;
                }
            }
            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    private void JumpIfAllowed()
    {
        if (swipeUp && rb.velocity.y == 0 || up)
        {
            rb.velocity = Vector2.up * jumpforce;
            swipeUp = false;
            up = false;
        }
    }

    private void Shoot()
    {
        if (Tap || swipeRight || tap)
        {
            Instantiate(Pr, Spawn.transform.position, Quaternion.identity);
            Tap = false;
            tap = false;
        }
    }

    private void DuckIfAllowed()
    {
        if (swipeDown == true)
        {
            colider.size = new Vector2(colider.size.x, 1.259054f);
            colider.offset = new Vector2(colider.offset.x, -0.214803f);
            sprite.enabled = false;
            timerReached = false;
            timer += Time.deltaTime;
            DuckCooldown = 0;
            if (!timerReached && timer > 0.75f)
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
        swipeDown = false;
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