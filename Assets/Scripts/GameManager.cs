using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public Button StartButtom;
    public Button LoadButtom;

    // Start is called before the first frame update
    void Start()
    {
        StartButtom = GameObject.Find("StartButton").GetComponent<Button>();


        StartButtom.onClick.AddListener(GetInGameFirst);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetInGameFirst()
    {
        SceneManager.LoadScene("SettingUI");
     
    }

}
