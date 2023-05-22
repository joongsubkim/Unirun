using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floattorm : MonoBehaviour
{
    public GameObject[] obstacles; // 장애물 오브젝트들
    private bool stepped = false; //플레이어 케릭터가 밟았는가
    //컴포넌트가 활성화 될 때마다 매번 실행되는 메서드
    private void OnEnable()
    {
        //발판을 리셋하는 처리
    }
   void OnjcollisionEnter2D(Collision2D collision)
    {
        //플레이어 케릭터가 자신을 밟았을 때 점수를 추가하는 처리
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
