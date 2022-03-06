using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    bool btn_active; //버튼 활성화 상태 유무 검사
    public Text[] text_time; //시간 표시할 text
    public Text btn_text; //상태에 따라 버튼의 text 변경하기 위한 text
    float time; //시간
    float cooking_time = 10.0f;
    float rest_time = 0.5f;
    void Start()
    {
        btn_active = false; //버튼 초기 상태 false로 만들기
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
            if (cooking_time- rest_time < time && time <cooking_time+ rest_time)
            {
                btn_text.text = "시간 일치 완료!";
            }
            else
            {
                btn_text.text = "시간 일치 실패..";
            }
            //btn_text.text = "STOP!";
            time = 0;
        }
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
        //늘어나는 타이머의 경우
        if (btn_active)
        {
            time += Time.deltaTime;
            //text_time[0].text = ((int)time % 60).ToString() + "sec";
            text_time[0].text = "Count...";
        }

        //줄어드는 타이머의 경우
        /*if (btn_active)
        {
            time -= Time.deltaTime;
            text_time[0].text = ((int)time / 3600).ToString();
            text_time[1].text = ((int)time / 60 % 60).ToString();
            text_time[2].text = ((int)time % 60).ToString();
        }*/
    }
}
