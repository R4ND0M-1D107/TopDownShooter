using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrapnel : MonoBehaviour
{
    float x;
    float y;
    Rigidbody2D rb;
    public float speed;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(x*speed, y*speed);
        Destroy(self, 0.8f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 12)
        {
            Destroy(self);
        }
    }


}
