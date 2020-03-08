using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    // 0 being radius light 1 being flash light
    public Light[] lightSource;    
    public SharedData sharedData;
    PlayerMovement playerMovement;
    PlayerTag playerTag;
    Vector2 mousePosition;
    public GameObject cursor;


    void Start()
    {
        //cursor = GameObject.Find("Cursor " + playerMovement.playerId.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.transform.position = mousePosition;
    }
}
