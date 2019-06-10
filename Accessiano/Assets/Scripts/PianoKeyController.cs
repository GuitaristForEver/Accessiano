using UnityEngine;
using System.Threading;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class PianoKeyController : MonoBehaviour
{
    // 1. Declare Variables
    Thread receiveThread; 
    UdpClient client; 
    int port; 

    public GameObject Player; 
    bool play; 

    private bool isTrigger = false;

    void Start()
    {
        port = 5065; 
        play = false;  

        InitUDP(); 
    }

    // 3. InitUDP
    private void InitUDP()
    {
        print("UDP Initialized");

        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void stopUDP()
    {
        print("UDP stoped");
        receiveThread.Abort();
    }

    // 4. Receive Data
    private void ReceiveData()
    {
        client = new UdpClient(port); //1
        while (true) //2
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port); //3
                byte[] data = client.Receive(ref anyIP); //4

                string text = Encoding.UTF8.GetString(data); //5
                print(">> " + text);

                play = true; //6

            }
            catch (Exception e)
            {
                print(e.ToString()); //7
            }
        }
    }

    void Update()
    {
        //play sound
        if (play==true)
        {
            OnPlay();
            play = false;
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

    void OnDestroy()
    {
        stopUDP();
    }
}
