using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerController�� �÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; //����� ����� ����� Ŭ��
    public float jumpForce = 700f; //������
    private int jumpCount = 0;
    private bool isGrounded = false; //�ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false; // ��� ����

    private Rigidbody2D playerRigidbody; //����� ������ �ٵ� ������Ʈ //
    private Animator Animator; //����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; //����� ����� �ҽ� ������Ʈ
    private void Start ()
    {
        //�ʱ�ȭ
        //���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isDead) // ���ϸ� ó�� �� ��� ���� if (isDead) return; �ص� �ȴ�.
        {
            //��� �� ó���� �� �̻� �������� �ʰ� ����
            return;

        }
        //���콺 ���� ��ư���������� && �ִ� ���� Ƚ��(2)�� �������� �ʾҴٸ�
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {//����Ƚ�� ����
            jumpCount++;
            //���� ������ �ӵ��� ���������� ���� (0,0)�� ����
            playerRigidbody.velocity = Vector2.zero;
            //������ �ٵ� �������� �� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //����� �ҽ� ���
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            //���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y ���� ������ (���� ��� ��)
            //���� �ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        //�ִϸ������� ground�Ķ���͸� isGrounded ������ ����
        Animator.SetBool("Grounded", isGrounded);
    }


    private void Die()
    {
        //�ִϸ������� Die Ʈ���� �Ķ���͸� ��
        Animator.SetTrigger("Die");
        //����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.Play();

        //�ӵ��� ����(0,0)�� ����
        isDead = true;
        //���� �Ŵ����� ���ӿ��� ó�� ����
        GameManager.instance.OnPlayerDead();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            //�浹�� ������ �±װ� Dead�̸� ���� ������� �ʾҴٸ� Die() ����
            Die();
        }            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //� �ݶ��̴��� �������, �浹 ǥ���� ������ ���� ������

        if (collision.contacts[0].normal.y > 0.7f)
        {
            //isgrounded��  true�� �����ϰ�, ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
