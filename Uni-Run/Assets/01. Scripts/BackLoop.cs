using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackLoop : MonoBehaviour
{
    private float width; //����� ���� ����

    private void Awake()
    {
        //���� ���̸� �����ϴ� ó��
        // Boxcollider2d������Ʈ�� size �ʵ��� x���� ���� ���̷� ���
        BoxCollider2D backgroundcollider = GetComponent<BoxCollider2D>();
        width = backgroundcollider.size.x;

        //Boxcollider2D backgroundcollider =
        //getComponent<Boxcollider2D>().size.x;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� ��ġ�� �������� �������� width �̻� �̵����� �� ��ġ�� ���ġ
        if(transform.position.x <= -width)
            {
            Reposition();
        }
    }

    //���� ��ġ�� �������� �������� width �̻� �̵����� �� ��ġ�� ���ġ
    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}

