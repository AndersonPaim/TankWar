using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
public class teste : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM3", 9600);

    void Start()
    {

        sp.Open();
        sp.ReadTimeout = 1;
        StartCoroutine(Read());
    }

    void Update()
    {

        if (sp.IsOpen)
        {
            try
            {
                // Mover(sp.ReadByte());
                Rodar(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }

      

    }
    IEnumerator Read()
    {
        while (true)
        {
            string[] val = sp.ReadLine().Split(',');
            float v = (float.Parse(val[0])) / 100;
            float h = (float.Parse(val[1])) / 100;
            yield return new WaitForSeconds(.05f);
        }
    }
    void Rodar(int y)
    {
        transform.rotation = Quaternion.Euler(0, y, 0);
    }


}