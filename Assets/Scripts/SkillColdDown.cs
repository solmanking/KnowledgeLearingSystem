using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillColdDown : MonoBehaviour
{
    // Start is called before the first frame update


    public float ColdDownTime=2.0f;
    private float Timer = 0;
    private Button Skill1;
    private Image FilledImage;
    private bool isStartTimer;
    public KeyCode Keycode;

    void Start()
    {
        FilledImage = transform.Find("FillSkill1").GetComponent<Image>();
        //Skill1 = GameObject.Find("Skill1").GetComponent<Button>();
        //Debug.Log("搜尋成功");
        FilledImage.fillAmount = 0;

        //Skill1.onClick.AddListener(OnClick);

        isStartTimer = false;

    }

    // Update is called once per frame
    void Update()
    {

    
            if (isStartTimer == true && Timer < ColdDownTime)
            {
                Timer += Time.deltaTime;
                FilledImage.fillAmount = (ColdDownTime - Timer) / ColdDownTime;
                Debug.Log("成功");
            }

            if (Timer >= ColdDownTime)
            {

                FilledImage.fillAmount = 0;
                isStartTimer = false;
                Timer = 0;


            }
    }

    
    public void OnClick()
    {
        //isStartTimer = true;
        SkillEffect();
    
    }
    
    public void SkillEffect()//這裡寫技能效果
    {
        isStartTimer = true;


        //isColdDown();
    
    }
    /*

    public void isColdDown()//冷卻時間
    {
        if (isStartTimer==true && Timer < ColdDownTime)
        {         
            Timer += Time.deltaTime;
            FilledImage.fillAmount = (ColdDownTime-Time.deltaTime) / ColdDownTime;
            Debug.Log("成功");
        }

        if (Timer >= ColdDownTime)
        {

            FilledImage.fillAmount =0 ;
            isStartTimer = false;
            Timer = 0;
            
        
        }
        
    
    }*/

    
}
