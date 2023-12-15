using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D RB;
    public float Speed = 5f;
    public float restartDelay = 1f;
    public ParticleSystem PS;
    public bool OnGround = true;
    public bool Movement = false;

    public GameObject Image;
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement == true)
            RB.velocity = (new Vector2(10, RB.velocity.y));

        //transform.position += transform.right * Speed * Time.deltaTime;
        /* Vector2 vel = RB.velocity;
         RB.AddForce(vel.x * Time.deltaTime,0,0);*/

        //transform.position = new Vector3(target.position.x, 0, transform.position.z);
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            if (Mathf.Sign(RB.gravityScale) == 1)
            {
                RB.gravityScale = -RB.gravityScale;
                //   RB.velocity = (new Vector2(10, 0));
            }
            else
            {
                RB.gravityScale = Mathf.Abs(RB.gravityScale);
            }
        }
        if (transform.position.y <= -20 || transform.position.y >= 20)
        {
            Invoke("Restart", 0);
        }

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Grounds")
        {
            OnGround = true;
        }
        if (other.gameObject.tag == "Obstacles")
        {
            Movement = false;
            Invoke("Restart", restartDelay);
            PS.Emit(10);
            RB.velocity *= .25f;
            //Destroy(gameObject);
        }
        if (other.gameObject.name == "Finished")
        {
            Text.SetActive(true);
            Image.SetActive(true);
            Movement = false;
            Invoke("nextlevel", restartDelay);
        }
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "DeathZone")
        {
            Movement = false;
            Invoke("Restart", restartDelay);
            PS.Emit(10);
            RB.velocity *= .25f;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Grounds")
        {
            OnGround = false;
        }
    }
}
