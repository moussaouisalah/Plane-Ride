using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Animator animator;
    public GameObject bullet;
    bool Shooting;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        Shooting = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                Shooting = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Shooting = false;
        }
    }

    void FixedUpdate()
    {
        animator.SetBool("Shooting", Shooting);
        timer += Time.deltaTime;
        if (Shooting && timer > 0.2f)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
