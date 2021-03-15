using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public bool horizontal = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ChageSplitScreen();
        }
    }
    public void ChageSplitScreen()
    {
        horizontal = !horizontal;
        if (horizontal)
        {
            cam1.rect = new Rect(0, 0, 1, 0.5f);
            cam2.rect = new Rect(0, 0.5f,1, 0.5f);

        }
        else
        {
            cam1.rect = new Rect(0, 0, 0.5f, 1);
            cam2.rect = new Rect(0.5f, 0, 0.5f, 1);
        }
    }
}
