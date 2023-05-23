using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plattorm : MonoBehaviour
{
    public GameObject[] obstacles; // ��ֹ� ������Ʈ��
    private bool stepped = false; //�÷��̾� �ɸ��Ͱ� ��Ҵ°�
    //������Ʈ�� Ȱ��ȭ �� ������ �Ź� ����Ǵ� �޼���
    private void OnEnable()
    {
        //���� ���¸� ����
        stepped = false;
        //��ֹ��� ����ŭ ����
        for (int i = 0; i < obstacles.Length; i++)
        {
            //���� ������ ��ֹ��� 1/3�� Ȯ���� Ȱ��ȭ
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);

            }

        }
    }
    //������ �����ϴ� ó��

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !stepped)
        {//�浹�� ������ �±װ� Player�̰� ������ �÷��̾� �ɸ��Ͱ� ���� �ʾҴٸ�
            //������ �߰��ϰ�, ���� ���¸� ������ ����
            stepped = true;
            GameManager.instance.AddScore(10);

            //�÷��̾� �ɸ��Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
        }
    }
}

   