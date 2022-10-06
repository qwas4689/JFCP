using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float Xinput { get; private set; }
    public float Zinput { get; private set; }
    public bool IsPackButtonPressed;
    private PlayerInteraction _playerInteraction;
    private Item _item;
    void Start()
    {
        _playerInteraction = GetComponent<PlayerInteraction>();
        _item = GetComponent<Item>();
    }

    void Update()
    {
        Xinput = Input.GetAxisRaw("Horizontal");
        Zinput = Input.GetAxisRaw("Vertical");
     

        
            if(OVRInput.GetDown(OVRInput.RawButton.B))
            {
                IsPackButtonPressed = true;
            }
            else
            {
                IsPackButtonPressed = false;
            }
        
        
    }

}
