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
        // ���� ��ȭ�� playerState�� �޾ƿ��� or �̺�Ʈ�� ��Ȳ �ޱ�
    }

    /// <summary>
    /// �÷��̾�� ����� �� ����
    /// </summary>
    /// <param name="other">�÷��̾�</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerState == Stealing)
            {
                // �÷��̾ ������ ������ �� Ȯ��
            }
        }
    }
}
