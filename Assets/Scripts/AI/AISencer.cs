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
        // ���� ��ȭ�� playerState�� �޾ƿ���   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // �÷��̾��� ���¸� �޾ƿͼ� �ൿ

            switch (playerState)
            {
                case 1:
                    // �÷��̾ Idle �϶� ����ħ
                    break;

                case 2:
                    // �÷��̾ ���� ������ �� 
                    break;

                case 3:
                    // �÷��̾ ������ �� ���� ���� ��
                    break;

                default:
                    // ����Ʈ
                    break;

            }
        }
    }
}
