using UnityEngine;

public class Spawner : MonoBehaviour
{


    public GameObject rocketPrefab;
    public float spawnRate = 1f;
    public float verticalRange = 4f;
    private float spawnTimer = 0f;

    void Update()
    {

        spawnTimer += Time.deltaTime;


        if (spawnTimer >= 1f / spawnRate)
        {

            spawnTimer = 0f;

            SpawnRocket();
        }
    }

    void SpawnRocket()
    {

        float randomY = Random.Range(transform.position.y - verticalRange / 2f, transform.position.y + verticalRange / 2f);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        GameObject newRocket = Instantiate(rocketPrefab, spawnPosition, transform.rotation);
    }
}
