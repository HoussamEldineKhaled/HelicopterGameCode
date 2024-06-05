using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Clamping : MonoBehaviour
{

    float minX;
    float minY;

    float maxX;
    float maxY;

    public Clamping(float worldMinX , float worldMinY, float worldMaxX , float worldMaxY, BoxCollider2D r){
        //calculate half the heights of the sprite
        float halfHeight = r.bounds.size.y/2.0f;
        float halfWidth = r.bounds.size.x/2.0f;
        //find border locations
        minX = worldMinX + halfWidth;

        minY = worldMinY + halfHeight;

        maxX = worldMaxX - halfWidth;

        maxY = worldMaxY - halfWidth;

    }

    public void limitMovement(Vector3 positionHeli, Transform trans)
    {

            float clampX = Mathf.Clamp(positionHeli.x, minX, maxX);
            float clampY = Mathf.Clamp(positionHeli.y, minY, maxY);

            trans.position = new Vector3(clampX, clampY, trans.position.z);


    }




}
