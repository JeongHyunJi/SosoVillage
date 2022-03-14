using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    //시간
    bool btn_active; //버튼 활성화 상태 유무 검사
    public Text[] text_time; //시간 표시할 text
    public Text btn_text; //상태에 따라 버튼의 text 변경하기 위한 text
    float time; //시간
    float cooking_time = 3.5f;
    float rest_time = 1.0f;

    //빵
    SpriteRenderer sr;
    public GameObject go;

    //씬 이동
    private int count = 0;
    private int countY = 0;
    private int countN = 0;

    void Start()
    {
        btn_active = false; //버튼 초기 상태 false로 만들기
        sr = go.GetComponent<SpriteRenderer>();
    }
    public void Btn_Click() //버튼 클릭 이벤트
    {
        if (!btn_active)
        {
            SetTimerOn();
            btn_text.text = "Stop!";

        }
        else
        {
            SetTimerOff();
            if (cooking_time- rest_time <= time && time <= cooking_time+ rest_time)
            {
                btn_text.text = "Game Complete!";
                InvokeRepeating("PrintFinalY", 2f, 3f);
            }
            else
            {
                btn_text.text = "Game Fail..";
                InvokeRepeating("PrintFinalN", 2f, 3f);
            }
            time = 0;
            InvokeRepeating("SceneChange", 3f, 3f);
        }
    }
    public void PrintFinalY()
    {
        btn_text.text = "You can get a bread!";
        countY += 1;
    }
    public void PrintFinalN()
    {
        btn_text.text = "You can't get a bread!";
        countN += 1;
    }
    public void SetTimerOn() //버튼 활성화 메소드
    {
        btn_active = true;
    }
    public void SetTimerOff() //버튼 비활성화 메소드
    {
        btn_active = false;
    }
    public void Update() //바뀌는 시간 text에 반영하는 update 생명주기
    {
        if (btn_active)
        {
            time += Time.deltaTime;
            if (2.5f <= time && time <= 4.5f)
            {
                text_time[0].text = "Nice Baking!";
                sr.material.color = new Color(0.90f, 0.68f, 0.19f);
            }
            else if (time > 4.5f && time<6.0f)
            {
                text_time[0].text = "Bread is Burning!";
                sr.material.color = new Color(0.49f, 0.35f, 0.04f);
            }
            else if (time >= 6.0f)
            {
                text_time[0].text = "Bread is All Burned..";
                sr.material.color = new Color(0.0f, 0.0f, 0.0f);
            }
            else
            {
                text_time[0].text = "Baking Now...";
                sr.material.color = new Color(1f, 1f,1f);
            }
        }
        if (count >= 1)
        {
            CancelInvoke("SceneChange");
        }
        if (countY >= 1)
        {
            CancelInvoke("PrintFinalY");
        }
        if (countN >= 1)
        {
            CancelInvoke("PrintFinalN");
        }
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("GameCookingPre");
        count += 1;
    }
}
