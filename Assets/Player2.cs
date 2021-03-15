using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{

    public float vel = 20;
    public float amountToMove;
    public Transform saidaTiro;
    public GameObject tiro;
    public string input;
    public int vida = 100;
    public GameObject textoVida, textoVidaInimigo, iconVida, iconVidaInimigo;
    public float delayTiro = 5;

    // Start is called before the first frame update
    void Start()
    {
        textoVida = GameObject.Find("textoVidaP1");
  
    }

    // Update is called once per frame
    void Update()
    {
        textoVida.GetComponent<Text>().text = vida.ToString();

        amountToMove = vel * Time.deltaTime;
        
        delayTiro += Time.deltaTime;

        if (delayTiro > 1)
        {
            if (Input.GetKeyDown("t"))
            {
                GameObject.Instantiate(tiro, saidaTiro.position, saidaTiro.rotation);
                delayTiro = 0;
            }
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(transform.forward * amountToMove, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(-transform.forward * amountToMove, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, Time.deltaTime * -100, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, Time.deltaTime * 100, 0);
        }


        if (vida <= 0)
        {
            SceneManager.LoadScene("Final2");
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tiro")
        {
            Destroy(collision.gameObject);
            vida -= 20;
        }
    }
}


