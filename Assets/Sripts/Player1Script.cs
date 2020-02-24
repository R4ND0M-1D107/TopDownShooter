using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal;
    float vertical;
    public Transform self;
    public float border;
    public Transform muzzle;
    public GameObject bullet;
    public float rotationSpeed;
    float rotSpeed;
    float rotation;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //rotation
        if (Input.GetKey(KeyCode.T))
        {
            rotSpeed = rotationSpeed;
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            rotSpeed = -rotationSpeed;
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            rotSpeed = -rotationSpeed;
        }
        else
        {
            rotSpeed = 0;
        }
        // movement input
        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
        }else if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
        }else
        {
            horizontal = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }
        else
        {
            vertical = 0;
        }

        // don't go outside of camera
        if (self.position.x < -border)
        {
            self.position = new Vector2(border, self.position.y);
        }else if (self.position.x > border)
        {
            self.position = new Vector2(-border, self.position.y);
        }else if (self.position.y > border)
        {
            self.position = new Vector2(self.position.x, -border);
        }else if (self.position.y < -border)
        {
            self.position = new Vector2(self.position.x, border);
        }

        //shooting
        if (Input.GetKeyDown(KeyCode.U))
        {
            Instantiate(bullet, muzzle.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        //movement
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        
        //rotation
        rotation += rotSpeed;
        transform.eulerAngles = new Vector3(0.0f, 0.0f, rotation);
    }

    void Death(int x)
    {
        if (x == 1)
        {
            Score.Player2Score++;
            self.position = new Vector2(-1.2f, 0);
        }
        else if (x == 2)
        {
            Score.Player1Score--;
            self.position = new Vector2(-1.2f, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Death(1);
        }
        else if (collision.gameObject.layer == 10)
        {
            Death(2);
        }
    }
}
