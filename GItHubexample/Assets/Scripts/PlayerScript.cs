using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
     public Transform target;
    public Rigidbody2D RB;
     public float Speed = 5f;
     public float restartDelay = 1f;
    public ParticleSystem PS;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.AddForce(new Vector2(1000, 0f)* Time.deltaTime);
        //transform.position += transform.right * Speed * Time.deltaTime;
       /* Vector2 vel = RB.velocity;
        RB.AddForce(vel.x * Time.deltaTime,0,0);*/
       
      //transform.position = new Vector3(target.position.x, 0, transform.position.z);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Sign(RB.gravityScale) == 1)
            {
                RB.gravityScale = - RB.gravityScale;
            }
            else 
            {
                RB.gravityScale = Mathf.Abs(RB.gravityScale);
            }
        }

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Spikes")
        {
             Invoke("Restart", restartDelay);
            PS.Emit(10);
            //Destroy(gameObject);
        }
        if (other.gameObject.name == "Finished")
        {

        }
    }
}
