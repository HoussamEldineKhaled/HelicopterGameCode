using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.5f;
    public float endPositionX = 33f;
    private bool hasReachedEnd = false;

    public Animator RocketAnim;

    void Start(){
        RocketAnim = GetComponent<Animator>();
        
    }

    void Update()
    {

        if (!hasReachedEnd)
        {
            float distanceToMove = speed * Time.deltaTime;

            transform.Translate(Vector3.right * distanceToMove);
            
            if (transform.position.x < endPositionX)
            {

                hasReachedEnd = true;


                transform.position = new Vector3(endPositionX, transform.position.y, transform.position.z);
                Destroy(gameObject);

            }
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("helicopter")){
            RocketAnim.SetBool("IsBooming", true);
        }
    }
}
