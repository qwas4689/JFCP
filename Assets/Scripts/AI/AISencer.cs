using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISencer : MonoBehaviour
{
    private PlayerInteraction playerInteraction;

    private int playerState;


    void Awake()
    {
        playerInteraction = GetComponent<PlayerInteraction>();
    }

    void Update()
    {
        // 상태 변화를 playerState에 받아오기   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // 플레이어의 상태를 받아와서 행동

            switch (playerState)
            {
                case 1:
                    // 플레이어가 Idle 일때 지나침
                    break;

                case 2:
                    // 플레이어가 포장 해제일 때 
                    break;

                case 3:
                    // 플레이어가 도둑질 한 것을 봤을 때
                    break;

                default:
                    // 디폴트
                    break;

            }
        }
    }
}
