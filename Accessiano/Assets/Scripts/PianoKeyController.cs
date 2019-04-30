using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKeyController : MonoBehaviour
{

    private bool isTrigger = false;

    void Start()
    {
        
    }


    void Update()
    {
        //play sound
        if (Input.GetKeyDown("space") && (isTrigger))
        {
            OnPlay();
        }
    }

    void OnPlay()
    {
        Debug.Log("enter to OnPlay()!!!!!");
        if (Input.GetKeyDown("space"))
        {
            GetComponent<AudioSource>().Play();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Eye")
        {
            this.isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Eye")
        {
            this.isTrigger = false;
        }
    }
}
