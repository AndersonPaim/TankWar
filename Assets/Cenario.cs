using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario : MonoBehaviour
{
    // Start is called before the first frame update

    float vida = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vida == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tiro")
        {
            Destroy(collision.gameObject);
            vida--;
        }
    }
}
