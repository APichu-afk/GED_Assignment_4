//https://unity3d.college/2017/05/26/unity3d-design-patterns-state-basic-state-machine/
//Above is the link we used for the state design pattern
//We adapted the code by changing the states from animations into the size of our object. We also made the state of the object change based on a keypress.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDesignPattern : MonoBehaviour
{
    //Using an enum to manage the state of the object
    public enum playerstate{
        Cube,
        Rectangle,
        LongerRectangle,
    }
    public GameObject player;//Gets the player object
    private playerstate currentstate;//Hides the player's state from the player

    // Start is called before the first frame update
    void Start()
    {
        currentstate = playerstate.Cube;//Initializes the state to be in a cube first
    }

    // Update is called once per frame
    void Update()
    {
        //When the player presses X the player will change its state to a cube
        if (Input.GetKeyDown(KeyCode.X))
        {
            currentstate = playerstate.Cube;
        }
        
        //When the player presses C the player will change its state to a rectangle
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentstate = playerstate.Rectangle;
        }
        
        //When the player presses V the player will change its state to a longer rectangle
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentstate = playerstate.LongerRectangle;
        }

        //Using a switch state to manage which state the player is in
        switch (currentstate)
        {
            case playerstate.Cube:
                player.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case playerstate.Rectangle:
                player.transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
                break;
            case playerstate.LongerRectangle:
                player.transform.localScale = new Vector3(1.0f, 3.0f, 1.0f);
                break;
        }
    }
}
