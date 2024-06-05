using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour

{
    public float speed;

    public float coinspeed;
    float xPos = 0;

    public GameObject anchorPrefab;
    public bool needsAnchor;


    // one-time startup
    void Start()
    {
        if(needsAnchor)
        {
            // launch a new anchor every 2 seconds
            InvokeRepeating("CreateAnchor", 0, 2.0f);
        }
    }


    void Update()
    {
        // update the x offset
        xPos += Time.deltaTime * speed;

        // keep offset in the 0.0 to 1.0 range
        if (xPos >= 1.0f)
        {
            xPos = 0.0f;
        }

        // build vector of new offset
        Vector2 offset = new Vector2(xPos, 0);

        // update the mainTextureOffset
        Renderer r = GetComponent<Renderer>();
        r.material.mainTextureOffset = offset;
        // update x position of all other "still" objects in the game
        float xChange = r.bounds.size.x * Time.deltaTime * coinspeed;



        // calculate the size of the screen, in world units
        float worldHeight = Camera.main.orthographicSize * 2.0F;
        float worldWidth = worldHeight * Camera.main.aspect;

        float xMin = -worldWidth / 2.0F;

        // for each tagged object we can find
        GameObject[] anchors = GameObject.FindGameObjectsWithTag("anchor");
        foreach (GameObject anch in anchors)
        {
            // move this object
            anch.transform.Translate(-xChange, 0, 0);

            // Get the new anchor's Renderer component
            Renderer anchorRenderer = anch.GetComponent<Renderer>();

            // if anchor position is less than the left side of the screen 
            // minus the width of the anchor
            if (anch.transform.position.x < xMin - anchorRenderer.bounds.size.x)
            {
                Destroy(anch);  // destroy this object
            }
        }

    }

    
    void CreateAnchor()
    {
        // calculate the size of the screen, in world units
        float worldHeight = Camera.main.orthographicSize * 2.0F;
        float worldWidth = worldHeight * Camera.main.aspect;
        float yMin = -worldHeight / 2.0F;
        float xMax = worldWidth / 2.0F;
        float yMax = worldHeight / 2.0F;

        // create new anchor prefab and get Renderer
        GameObject anchor = Instantiate(anchorPrefab);
        Renderer r = anchor.GetComponent<Renderer>();

        // calculate x position just off the side of the screen
        float x = xMax + r.bounds.size.x;

        // calculate random Y position between top and bottom
        float y = Random.Range(yMin + 7, yMax - 2);

        // update new prefab's position
        anchor.transform.position = new Vector3(x, y ,-1.4f);
    }

}
