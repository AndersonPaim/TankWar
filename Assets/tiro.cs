using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour
{

    public float tempo = 0;
    public int forca = 100;
    public Rigidbody rb;
    public GameObject particulaExplosao;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.AddForce(transform.forward * forca);
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        transform.Translate(transform.forward * forca, Space.World);

        if (tempo >= 5)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cenario")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Tanque")
        {
            Destroy(gameObject);
            GameObject.Instantiate(particulaExplosao, transform.position, transform.rotation);
        }
    }
}
