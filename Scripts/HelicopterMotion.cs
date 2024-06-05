using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicopterMotion : MonoBehaviour
{
    public TextMeshProUGUI tScore;
    public int score = 0;
    private Rigidbody2D rb;
    public AudioSource HelicopterSound;
    public AudioSource CoinCollect;
    public AudioSource Boom;
    public Animator helianim;
    public bool isDead = false;
    public float jump;
    private float speed;
    Clamping heliclamp;
    private BoxCollider2D playerCollider;

    public String nextScene;


    void Start()
    {
        //Get component of rigid body
        rb = GetComponent<Rigidbody2D>();
        //Get component of helicopter
        playerCollider = GetComponent<BoxCollider2D>();
        //get the animator
        helianim = GetComponent<Animator>();

        //find coordinates of the game's border
        float worldHeight = Camera.main.orthographicSize * 2.0f;

        float worldWidth = worldHeight * Camera.main.aspect;

        float Xmin = -worldWidth / 2.0f;
        float Ymin = -worldHeight/ 2.0f;
        float Xmax = worldWidth / 2.0f;
        float Ymax = worldHeight / 2.0f;

        //initialise the clamping variable
        heliclamp = new Clamping(Xmin, Ymin, Xmax, Ymax, playerCollider);

        HelicopterSound.Play();

        tScore.text = "Score: " + score;
    }
    void Update()
    {
            if(isDead == false){
                //helicopter movement
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.AddForce(new Vector2(rb.velocity.x, jump));
                } else if (Input.GetKey(KeyCode.RightArrow)){
                    speed = 7;
                } else if (Input.GetKey(KeyCode.LeftArrow)){
                    speed = -6;
                } else {
                    speed = 0;
                }
                rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                heliclamp.limitMovement(transform.position, transform);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("anchor"))
        {
            score++;
            tScore.text = "Score: "+ score;
            CoinCollect.Play();
            Destroy(col.gameObject);
            if (score == 25)
            {
                SceneManager.LoadScene(nextScene);
            }

        }

        if (col.gameObject.CompareTag("danger")){
            GameOver();
        }
    }

    private void GameOver() {
        helianim.SetBool("IsDead", true);
        HelicopterSound.Stop();
        tScore.text = "Game Over";
        tScore.color = Color.red;
        Boom.Play();
        playerCollider.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
}
