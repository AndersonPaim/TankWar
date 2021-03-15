using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{

    public float tempo;
    // Start is called before the first frame update
    public void Start()
    {

    }

    public void Update()
    {
        tempo += Time.deltaTime;

        if(tempo > 5)
        {
            SceneManager.LoadScene("Arduino");
        }
    }

}
