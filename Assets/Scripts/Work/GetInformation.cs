using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetInformation : MonoBehaviour
{
    // Start is called before the first frame update

    public string SubjectName;
    public int DailyChooce;
    public string Name;
    public int AnswerRightNum;
    public int AnswerTotalNum;


    public Text DayText;//剩餘天數顯示
    public Text ConquereText;//完成關卡數量顯示
  


    public GameObject information;
    public Image MainInfor;
    public Image ItemTab;

    public GameObject Background;
    public Image BasicBar;
    public Image Day;
    public Image QuestConquere;
    public Text TextForDay;
    public Text TextForQuestConquere;



    public Toggle ItemToggle;

    void Start()
    {
        LoadInformation();//讀值
        Debug.Log(Name);
        Debug.Log(DailyChooce);
        Debug.Log(SubjectName);
        Debug.Log(AnswerTotalNum);
        ////////////////////////////
        ///
        ///////搜尋樹///////////////////
        information = GameObject.Find("information");
        MainInfor = information.transform.Find("MainInfor").GetComponent<Image>();

        Background = GameObject.Find("background");
        BasicBar = Background.transform.Find("BasicBar").GetComponent<Image>();
        Day = BasicBar.transform.Find("Day").GetComponent<Image>();
        QuestConquere=BasicBar.transform.Find("QuestConquere").GetComponent<Image>();
        TextForDay = Day.transform.Find("Text").GetComponent<Text>();
        TextForQuestConquere = QuestConquere.transform.Find("Text").GetComponent<Text>();


        ///初始化道具欄界面
        ItemTab = MainInfor.transform.Find("ItemTab").GetComponent<Image>();
        ItemToggle = ItemTab.GetComponent<Toggle>();
        ItemToggle.isOn = true;


   
        TextForDay.text = "天數:" + DailyChooce;
        TextForQuestConquere.text = "答題數:"+ AnswerRightNum+"/"; ///+AnswerRightNum





    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializationInterface()
    { 
    
        
    
    
    }





    private void LoadInformation()
    {
        FileStream fs = new FileStream(Application.dataPath + "/SaveClassInformation" + 1 + ".txt", FileMode.Open);//開啟該地址的檔案
        StreamReader sr = new StreamReader(fs); //讀取這個fs檔案
        data.Name = sr.ReadLine();
        data.DailyChooce = int.Parse(sr.ReadLine());
        data.SubjectName = sr.ReadLine();
        data.AnswerTotalNum =int.Parse(sr.ReadLine());

        Name = data.Name;
        DailyChooce = data.DailyChooce;
        SubjectName = data.SubjectName;
        AnswerTotalNum = data.AnswerTotalNum;
        //data.name = sr.ReadLine();//讀取name 資料
        //data.level = int.Parse(sr.ReadLine());//讀取level資料後將從字串其變整數

    }


    [SerializeField]
    Text Confirm_ui;

    [SerializeField] //建造一個"PlayerData"的物件
    PlayerData data;


    /// <summary>
    ///這裡是儲存資料區域
    /// </summary>
    [System.Serializable] //物件資料
    public class PlayerData   ///這裡是記事本儲存資料用的變數
    {
        public string SubjectName;
        public int DailyChooce;
        public string Name;
        public int AnswerTotalNum;
    }


}
