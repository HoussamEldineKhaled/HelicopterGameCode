using UnityEngine;

public class buildingSpawner : MonoBehaviour
{
    public float spawnRate = 0.2f;
    private float spawnTimer = 0;
    public GameObject buildingPrefab;



    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= 1 / spawnRate){
            spawnTimer = 0;
            spawnBuilding();
        }
    }

    void spawnBuilding(){
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, -1.5f);
        GameObject building = Instantiate(buildingPrefab, spawnPosition, transform.rotation);
    }
}
