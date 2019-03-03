using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKeyController : MonoBehaviour
{
    private Color PianoKey_EyeOverColor;
    private Color PianoKey_OriginalColor;
    private SpriteRenderer s_Render;

    private bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        //save the original color
        this.s_Render = GetComponent<SpriteRenderer>();
        this.PianoKey_OriginalColor = this.s_Render.material.color;

        //save the eyeOverColor
        if (this.tag == "WhitePianoKey")
        {
            PianoKey_EyeOverColor = Color.gray;
        }

        if (this.tag == "BlackPianoKey")
        {
            PianoKey_EyeOverColor = Color.red;
        }
     
    }

    // Update is called once per frame
    void Update()
    {
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
            Debug.Log("Input.GetKeyDown(space)!!!!!");
            //play the sound
            GetComponent<AudioSource>().Play();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Eye")
        {
            //change the color
            this.s_Render.material.color = this.PianoKey_EyeOverColor;

            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Eye")
        {
            //change to original color
            this.s_Render.material.color = this.PianoKey_OriginalColor;

            isTrigger = false;
        }
    }
}
