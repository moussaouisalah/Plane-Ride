using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public GameObject obstacle;
    float obstacleMinY = -4f;
    float obstacleMaxY = 2f;
    float obstacleY;
    public float spawnRate = 20f;
    float nextSpawn;
    Vector2 whereToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            obstacleY = Random.Range(obstacleMinY, obstacleMaxY);
            whereToSpawn = new Vector2(5, obstacleY);
            Instantiate(obstacle, whereToSpawn, Quaternion.identity);
        }
    }
}
