using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseQuest : MonoBehaviour
{
    // Start is called before the first frame update

    public Button InterButton;
    public GameObject information;
    public Image MainInfor;
    public Image QuestPanel;
    public Image TestPanel;

    public Image QuestionBar;
    public Image SentAnsButton;
    public Button SentAnsButtonClick;







    void Start()
    {

        information = GameObject.Find("information");
        MainInfor = information.transform.Find("MainInfor").GetComponent<Image>();

        QuestPanel = MainInfor.transform.Find("QuestPanel").GetComponent<Image>();
        TestPanel = MainInfor.transform.Find("TestPanel").GetComponent<Image>();
        QuestionBar = TestPanel.transform.Find("QuestionBar").GetComponent<Image>();
        //QuestionBar = GameObject.Find("Canvas/information/TestPanel/QuestionBar");       



        ///點選進入關卡設置
        InterButton = this.GetComponent<Button>();
        InterButton.onClick.AddListener(IntoQuest);



        /////送出答案設置
         SentAnsButton = QuestionBar.transform.Find("DecisionButton").GetComponent<Image>();
        //SentAnsButton = GameObject.Find("Canvas/information/TestPanel/QuestionBar/DecisionButton").GetComponent<Image>();
        SentAnsButtonClick = SentAnsButton.GetComponent<Button>();
        SentAnsButtonClick.onClick.AddListener(SentAns);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IntoQuest()///這裡要重置所有數值
    {

        QuestPanel.gameObject.SetActive(false);//關閉選關畫面
        TestPanel.gameObject.SetActive(true);//開啟解題畫面

    }



    public void SentAns()
    {

        QuestPanel.gameObject.SetActive(true);//關閉選關畫面
        TestPanel.gameObject.SetActive(false);//開啟解題畫面

    }

}
