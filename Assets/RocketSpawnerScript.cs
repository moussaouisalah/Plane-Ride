using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    float planeY;
    float randY;
    public float spawnRate = 10f;
    float difficulty = 0f;
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
            nextSpawn = Time.time + spawnRate - difficulty;
            if (difficulty < spawnRate - 1)
                difficulty += 1f;
            planeY = GameObject.Find("Plane").transform.position.y;
            randY = Random.Range(planeY - 1, planeY + 1);
            whereToSpawn = new Vector2(3, randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}
