using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float Xinput { get; private set; }
    public float Zinput { get; private set; }
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
     

        if(_item.CurrentState != EItemState.GRASPED) // unpick
        {

            if(OVRInput.GetDown(OVRInput.RawButton.B))
            {
                if(_item.CurrentState == EItemState.PACKED) // packed
                {
                    _playerInteraction.OnUnPack.Invoke();

                }
                else if(_item.CurrentState == EItemState.UNPACKED)
                {
                    _playerInteraction.Onpack.Invoke();

                }
            }

        }
        
    }

}
