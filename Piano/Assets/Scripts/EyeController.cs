using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class EyeController : MonoBehaviour
{
    public int minTobii = 170;
    public int maxTobii = 900;
    public int minScreen = -9;
    public int maxScreen = 6;

    private Vector2 _speed = new Vector2(600, 600);
    private Vector2 _movement;
    private Rigidbody2D _rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EyeMovement();
        //Tobii();

    }

    private void EyeMovement()
    {
        //using keyboard
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        _movement = new Vector2(inputX * _speed.x * Time.deltaTime, inputY * _speed.y * Time.deltaTime);
        _rigidBody.velocity = _movement;

    }

    /*
    private void Tobii()
    {

        //Tobii:
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        if (gazePoint.IsRecent()) // Use IsValid property instead to process old but valid data
        {
            float resultX = minScreen + (gazePoint.Screen.x - minTobii) * (maxScreen - minScreen) / (maxTobii - minTobii);
            // Note: Values can be negative if the user looks outside the game view.
            print("Gaze point on Screen (X,Y): " + gazePoint.Screen.x + ", " + gazePoint.Screen.y);
            transform.position = new Vector3(resultX, transform.position.y, transform.position.z);
        }

    }
    */
}
