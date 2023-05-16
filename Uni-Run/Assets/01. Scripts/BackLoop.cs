using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackLoop : MonoBehaviour
{
    private float width; //배경의 가로 길이

    private void Awake()
    {
        //가로 길이를 측정하는 처리
        // Boxcollider2d컴포넌트의 size 필드의 x값을 가로 길이로 사용
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
        //현재 위치가 원점에서 왼쪽으로 width 이상 이동했을 때 위치를 재배치
        if(transform.position.x <= -width)
            {
            Reposition();
        }
    }

    //현재 위치가 원점에서 왼쪽으로 width 이상 이동했을 때 위치를 재배치
    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}

