using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floattorm : MonoBehaviour
{
    public GameObject[] obstacles; // ��ֹ� ������Ʈ��
    private bool stepped = false; //�÷��̾� �ɸ��Ͱ� ��Ҵ°�
    //������Ʈ�� Ȱ��ȭ �� ������ �Ź� ����Ǵ� �޼���
    private void OnEnable()
    {
        //������ �����ϴ� ó��
    }
   void OnjcollisionEnter2D(Collision2D collision)
    {
        //�÷��̾� �ɸ��Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
