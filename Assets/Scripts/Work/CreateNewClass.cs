using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text;



using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;






public class CreateNewClass : MonoBehaviour
{
    // Start is called before the first frame update


    public InputField NameInputField;
    public Dropdown SubjectDropDown;
    public Dropdown DailyDropDown;
    public Button BirthButton;
    public Image Board2;
    public GameObject SearchMap;

    public string SubjectName;
    public int DailyChooce;
    public string Name;
    //public int AnswerTotalNum;


    void Start()
    {

        SearchMap = GameObject.Find("BoardManager");//用此當根點去搜尋他下面的物件
        Board2 =SearchMap.transform.Find("Board2").GetComponent<Image>();
        //Debug.Log("抓取");
        NameInputField = Board2.transform.Find("NameInputField").GetComponent<InputField>();
        SubjectDropDown = Board2.transform.Find("SubjectDropdown").GetComponent<Dropdown>();
        DailyDropDown = Board2.transform.Find("DailyDropdown").GetComponent<Dropdown>();
        BirthButton = Board2.transform.Find("BirthButton").GetComponent<Button>();

        SubjectDropDown.onValueChanged.AddListener(SubjectListener);
        DailyDropDown.onValueChanged.AddListener(DailyListener);
        //NameInputField.onValueChanged.AddListener(NameListener):
      

        SubjectName = "微積分";
        DailyChooce = 30;


    }

    // Update is called once per frame
    void Update()
    {
        BirthButton.onClick.AddListener(BirthClass);

    }

    public void SubjectListener(int index)
    {

        
        if (index == 0) {
            SubjectName = "微積分";
        }
        if (index == 1) {
            SubjectName = "會計學";
        }
        Debug.Log(SubjectName);

    }/////////////////////////////////////////


    public void DailyListener(int index) 
    {

        if (index == 0) {

            DailyChooce = 30;
        }

        if (index == 1) {

            DailyChooce = 60;
        }


        Debug.Log("選擇"+DailyChooce+"天");
        
    
    
    }//////////////////////////////////////







    private void BirthClass()
    {
        if (NameInputField.text!="")//確定名字是否有輸入
        {
            ///將輸入的值塞入data內的變數中
            data.Name =NameInputField.text;
            data.SubjectName = SubjectName;
            data.DailyChooce = DailyChooce;
            data.AnswerTotalNum = 0;
          
    FileStream fs = new FileStream(Application.dataPath + "/SaveClassInformation"+1+".txt", FileMode.Create);//於本地址創建檔案流，測試可以在中間加入數字，可用於多存檔時判定創建
            StreamWriter sw = new StreamWriter(fs);//設立檔案流寫手並要求其寫創立的fs檔案流
            
            sw.WriteLine(data.Name);
            sw.WriteLine(data.DailyChooce);
            sw.WriteLine(data.SubjectName);
            sw.WriteLine(data.AnswerTotalNum);
            sw.Close();
            fs.Close();
            //ui_text.text = "儲存完畢";
            Debug.Log("存檔完畢");

            SceneManager.LoadScene("02-BasicIntetface");
        }

        else
        {

            Debug.Log("尚有未輸入欄位");
        
        }
    
    
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
