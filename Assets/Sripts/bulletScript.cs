using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    Transform Muzzle;
    Transform RotationModifier;
    public float Speed;
    Vector2 rotation;
    Rigidbody2D rb;
    public GameObject self;
    Transform self1;
    public float border;
    [Range(1, 2)]
    public int selfNumber;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (selfNumber == 1)
        {
            Muzzle = GameObject.FindGameObjectWithTag("Muzzle1").GetComponent<Transform>();
            RotationModifier = GameObject.FindGameObjectWithTag("VectorMod1").GetComponent<Transform>();
        } else if (selfNumber == 2)
        {
            Muzzle = GameObject.FindGameObjectWithTag("Muzzle2").GetComponent<Transform>();
            RotationModifier = GameObject.FindGameObjectWithTag("VectorMod2").GetComponent<Transform>();
        }
        
        rotation = Muzzle.position - RotationModifier.position;
        StartCoroutine(selfDestroy());
        self1 = self.transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = rotation * Speed;

        if (self1.position.x < -border)
        {
            self1.position = new Vector2(border, self1.position.y);
        }
        else if (self1.position.x > border)
        {
            self1.position = new Vector2(-border, self1.position.y);
        }
        else if (self1.position.y > border)
        {
            self1.position = new Vector2(self1.position.x, -border);
        }
        else if (self1.position.y < -border)
        {
            self1.position = new Vector2(self1.position.x, border);
        }
    }

    IEnumerator selfDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(self);
    }
}
