using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;



//���ӿ��� ���¸� ǥ���ϰ�, ���� ������ UI�� �����ϴ� ���ӸŴ���
//������ �� �ϳ��� ���� �Ŵ����� ������ �� ����
public class GameManager : MonoBehaviour
{
    public static GameManager instance; //�̱����� �Ҵ��� ���� ����

    public bool isGameover = false; //���ӿ��� ����
    public TextMeshProUGUI scoreText; //������ ����� UI �ؽ�Ʈ
    public GameObject gameoverUI; //���� ���� �� Ȱ��ȭ �� UI ���� ������Ʈ
    
    private int score = 0; //���� ����

    //���ӽ��۰� ���ÿ� �̱����� ����


    
    private void Awake()
    {
        if (instance == null)
        {

            // instance�� ��� �ִٸ� (null)�װ��� �ڱ� ������ Ȱ��
            instance = this;
        }
        else
        {
            //instance�� �̹� �ٸ� GameManager������Ʈ�� �Ҵ�Ǿ� �ִ� ���

            //���� �� �� �̻��� GameMager������Ʈ�� �����Ѵٴ� �ǹ�
            //�̱��� ������Ʈ�� �ϳ��� ���� �ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    // void Start()

    //���� ���� ���¿��� ������ ����� �Ҽ� �ְ� �ϴ� ó��

    //������ ������Ű�� �޼���
    public void Addscore(int newScore)
    {

    }
    //�÷��̾� �ɸ��� ��� �� ���� ������ �����ϴ� �ż���
   
    public void AddScore(int newScore)
    {
        //���ӿ����� �ƴ϶��
        if(!isGameover)
        {
            //������ ����
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
   
    
    // Update is called once per frame
    void Update()
    {
      
        if (isGameover && Input.GetMouseButtonDown(0))
            {
            //���ӿ��� ���¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ� ���� �� �����
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
