using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool Pressed;
    public bool Destroyed;
    bool canControl;
    float velocity;
    public Animator animator;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Pressed = false;
        canControl = true;
        Destroyed = false;
        velocity = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                Pressed = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Pressed = false;
        }
    }

    void FixedUpdate()
    {
        if (Pressed && canControl)
        {
            if(velocity < 2)
                velocity += 0.15f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocity*velocity);
        }
        else
        {
            if (velocity > 0.2)
            {
                velocity -= 0.3f;
            }
            else
                velocity = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Coin")
        {
            if (collision.gameObject.tag == "Rocket")
                Destroy(collision.gameObject);
            canControl = false;
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroyed = true;
            animator.SetBool("Destroyed", true);
        }
        else
        {
            Score.score++;
            Destroy(collision.gameObject);
        }
    }
}
