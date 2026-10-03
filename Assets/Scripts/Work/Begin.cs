using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    // Start is called before the first frame update


    public Button StartButton;
    public Button LoadButton;
    public GameObject SearchMap;
    public Image Board1;
    public Image Board2;
    void Start()
    {
        //Board1 = transform.Find("Canvas/BoardManager/Board1").GetComponent<Image>();
        //Board2 = transform.Find("Canvas/BoardManager/Board2").GetComponent<Image>();

        SearchMap = GameObject.Find("BoardManager");//用此當根點去搜尋他下面的物件
        Debug.Log("Map成功");

        Board1 = SearchMap.transform.Find("Board1").GetComponent<Image>();
        Board2 = SearchMap.transform.Find("Board2").GetComponent<Image>();
        Debug.Log("board成功");
        Board1.gameObject.SetActive(true);
        Board2.gameObject.SetActive(false);

        StartButton = Board1.transform.Find("StartButton").GetComponent<Button>();
        StartButton.onClick.AddListener(ChangePage);

        LoadButton = Board1.transform.Find("LoadButton").GetComponent<Button>();
        LoadButton.onClick.AddListener(LoadPass);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePage()
    {
        //StartButton.gameObject.SetActive(false);
        Board1.gameObject.SetActive(false);
        Board2.gameObject.SetActive(true);
        Debug.Log("成功");

    
    }

    public void LoadPass()
    {

        SceneManager.LoadScene("02-BasicIntetface");

    }

}
