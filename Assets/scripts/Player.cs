using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float vel = 20;
    public float amountToMove;
    public float sensibilidade = 2, delayTiro = 5;
    public Transform saidaTiro;
    public GameObject tiro;
    public string[] inputList;
    public string input;
    public int vida = 100;
    public GameObject particulaExplosao;
    //public Text textoVida;
    SerialPort sp = new SerialPort("COM3", 9600);
    public GameObject textoVida, textoVidaInimigo, iconVida, iconVidaInimigo;


    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    
        textoVida = GameObject.Find("textoVidaP2");
       
    }

    // Update is called once per frame
    void Update()
    {
        textoVida.GetComponent<Text>().text = vida.ToString();

        amountToMove = vel * Time.deltaTime;
        delayTiro += Time.deltaTime;

        //moviment();

        if (sp.IsOpen)
        {
            try
            {
                Debug.Log(input = sp.ReadLine());
                inputList = input.Split(',');
               
                for (int i = 0; i < inputList.Length; i++)
                {
                    if (inputList[i].Contains("R")) //rotacao
                    {
                        rotate(float.Parse(inputList[i].Remove(0,1)));
                    }
                    else if (inputList[i].Contains("A")) //botao 1
                    {
                        moviment(float.Parse(inputList[i].Remove(0, 1)));
                    }
                    else if (inputList[i].Contains("B")) //botao 2
                    {
                        moviment2(float.Parse(inputList[i].Remove(0, 1)));
                    }
                    else if (inputList[i].Contains("C")) //botao 3
                    {
                        if(float.Parse(inputList[i].Remove(0, 1)) == 1)
                        {
                            Atirar();
                        }
                    }
                }
            }
            catch (System.Exception)
            {
               
            }
        }

        if (Input.GetKeyDown("space"))
        {
            Atirar();
        }

        if(vida <= 0)
        {
            SceneManager.LoadScene("Final1");
        }
    }
   
    void moviment(float direcao)
    {
        if (direcao == 1)
        {
            transform.Translate(transform.forward * amountToMove, Space.World);
        }
    }
    void moviment2(float direcao)
    {
        if (direcao == 1)
        {
            transform.Translate(-transform.forward * amountToMove, Space.World);
        }
    }

    void rotate(float rotacao)
    { 
         transform.rotation = Quaternion.Euler(0, rotacao / sensibilidade, 0);
    }
    
    void Atirar()
    {
        if (delayTiro > 1)
        {
            GameObject.Instantiate(tiro, saidaTiro.position, saidaTiro.rotation);
            delayTiro = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tiro")
        {
            vida -= 20;

        }
    }


}


