using System.Collections;
using UnityEngine;

public class buildingMove : MonoBehaviour
{
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
        Physics2D.IgnoreLayerCollision(6 , 7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0 , 0);
        if(transform.position.x < -23){
            Destroy(gameObject);

        }
    }


}
