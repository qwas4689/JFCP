using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISencer : MonoBehaviour
{
    private PlayerInteraction playerInteraction;
    private Camera aiSight;

    private int playerState;


    void Awake()
    {
        playerInteraction = GetComponent<PlayerInteraction>();
    }

    void Update()
    {
        // 상태 변화를 playerState에 받아오기 or 이벤트로 상황 받기
    }

    /// <summary>
    /// 플레이어와 닿았을 때 실행
    /// </summary>
    /// <param name="other">플레이어</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerState == Stealing)
            {
                // 플레이어가 도둑질 상태일 때 확인
            }
        }
    }
}
