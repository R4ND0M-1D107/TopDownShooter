using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    public GameObject Shrapnel;
    public GameObject Self;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        selfDestruct();
    }

    private void selfDestruct()
    {
        for (int x = 1; x < 7; x++)
        {
            Instantiate(Shrapnel, Self.transform.position, Quaternion.identity);
        }
        Destroy(Self);
    }


}
