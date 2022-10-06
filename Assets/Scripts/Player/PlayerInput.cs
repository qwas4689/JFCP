using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float Xinput { get; private set; }
    public float Zinput { get; private set; }
    public bool IsPackButtonPressed { get; private set; }

    void Start()
    {

    }

    void Update()
    {
        Xinput = Input.GetAxisRaw("Horizontal");
        Zinput = Input.GetAxisRaw("Vertical");

        IsPackButtonPressed = OVRInput.GetDown(OVRInput.RawButton.B);

    }

}
