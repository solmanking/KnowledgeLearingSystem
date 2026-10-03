using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///存檔練習用
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class SaveAndLoad : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
        Text ui_text;
    [SerializeField]
    PlayerData data;
 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*///僅存於Unity中
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetString("name",data.name);
            PlayerPrefs.SetInt("level",data.level);
            ui_text.text = "儲存完畢";
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            data.name = PlayerPrefs.GetString("name");
            data.level = PlayerPrefs.GetInt("level");
            ui_text.text = data.name + data.level;
        
        }*/


        ////儲存在本地端的記事本中
        if (Input.GetKeyDown(KeyCode.S))
        {
            FileStream fs = new FileStream(Application.dataPath + "/Save.txt", FileMode.Create);//於本地址創建檔案流
            StreamWriter sw = new StreamWriter(fs);//設立檔案流寫手並要求其寫創立的fs檔案流

            sw.WriteLine(data.name);
            sw.WriteLine(data.level);
            sw.Close();
            fs.Close();
            ui_text.text = "儲存完畢";
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            FileStream fs = new FileStream(Application.dataPath + "/Save.txt", FileMode.Open);//開啟該地址的檔案
            StreamReader sr = new StreamReader(fs); //讀取這個fs檔案
            data.name = sr.ReadLine();//讀取name 資料
            data.level = int.Parse(sr.ReadLine());//讀取level資料後將從字串其變整數
                
        }
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {

            PlayerPrefs.SetString("jsondata", JsonUtility.ToJson(data));
            
            ui_text.text = "儲存完畢";
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("jsondata"));

        }*/
    }

    [System.Serializable] //物件資料
    public class PlayerData
    {
        public string name;
        public int level;
    
    }


}
