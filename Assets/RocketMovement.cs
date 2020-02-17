using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(4, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x < -3)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-moveSpeed,0);
    }
}
