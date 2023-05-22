using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어함

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; //사망시 재생할 오디오 클립
    public float jumpForce = 700f; //점프힘
    private int jumpCount = 0;
    private bool isGrounded = false; //바닥에 닿았는지 나타냄
    private bool isDead = false; // 사망 상태

    private Rigidbody2D playerRigidbody; //사용할 리지드 바디 컴포넌트 //
    private Animator Animator; //사용할 애니메이터 컴포넌트
    private AudioSource playerAudio; //사용할 오디오 소스 컴포넌트
    private void Start ()
    {
        //초기화
        //게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isDead) // 리턴만 처리 할 경우 한줄 if (isDead) return; 해도 된다.
        {
            //사망 시 처리를 더 이상 진행하지 않고 종료
            return;

        }
        //마우스 왼쪽 버튼을눌렀으며 && 최대 점프 횟수(2)에 도달하지 않았다면
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {//점프횟수 증가
            jumpCount++;
            //점프 직전에 속도를 순간적으로 제로 (0,0)로 변경
            playerRigidbody.velocity = Vector2.zero;
            //리지드 바디에 위쪽으로 힘 주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //오디오 소스 재생
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            //마우스 왼쪽 버튼에서 손을 때는 순간 && 속도의 y 값이 양수라면 (위로 상승 중)
            //현재 속도를 절반으로 변경
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        //애니메이터의 ground파라미터를 isGrounded 값으로 갱신
        Animator.SetBool("Grounded", isGrounded);
    }


    private void Die()
    {
        //애니메이터의 Die 트리거 파라미터를 셋
        Animator.SetTrigger("Die");
        //오디오 소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.Play();

        //속도를 제로(0,0)로 변경
        isDead = true;
        //게임 매니저의 게임오버 처리 실행
        GameManager.instance.OnPlayerDead();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            //충돌한 상대방의 태그가 Dead이며 아직 사망하지 않았다면 Die() 실행
            Die();
        }            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //어떤 콜라이더와 닿았으며, 충돌 표면이 윗쪽을 보고 있으면

        if (collision.contacts[0].normal.y > 0.7f)
        {
            //isgrounded를  true로 변경하고, 누적 점프 횟수를 0으로 리셋
            isGrounded = true;
            jumpCount = 0;
        }
    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
