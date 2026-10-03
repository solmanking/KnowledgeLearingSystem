using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelScroll : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{

    private ScrollRect ScrollRect;

    private float[] PageArray = new float[] {0,0.975f };

    public int SmoothSpeed = 5;

    public bool isDraging = false;

    public Toggle[] ToggleArray; //儲存toogle們的位置

    private float targetHorizontalPosition=0;
    // Start is called before the first frame update
    void Start()
    {
        ScrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDraging == false)
        {
            ScrollRect.horizontalNormalizedPosition = Mathf.Lerp(ScrollRect.horizontalNormalizedPosition, targetHorizontalPosition, Time.deltaTime * SmoothSpeed);
        }
       
    }



    public void OnBeginDrag(PointerEventData eventData)//偵測拖動物件的起始與終點
    {
        //throw new System.NotImplementedException();
        isDraging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;
        //Debug.Log(ScrollRect.horizontalNormalizedPosition);
        //throw new System.NotImplementedException();
        float posX = ScrollRect.horizontalNormalizedPosition;
        int index = 0;                                        //初始化當前頁面標籤

        float offset = Mathf.Abs(PageArray[index] - posX);    //取當前位置與頁面量化座標的絕對值(離page最近的位置)
        for (int i = 1; i < PageArray.Length; i++)            //可動至量化頁面座標的最大值
        {
            float offsetTemp = Mathf.Abs(PageArray[i] - posX);//設一變數offset把頁面數量進行量化
            if (offsetTemp < offset)                          //當該變數小於當前位置時，將當前頁面設為i，當前座標設為offset
            {
                index = i;
                offset = offsetTemp;
            
            }
        
        }
        //ScrollRect.horizontalNormalizedPosition = PageArray[index]; //跳頁
        targetHorizontalPosition = PageArray[index];
        ToggleArray[index].isOn = true;                        
        
    }

    public void TurnPage1(bool IsOn)//確認按下toggle
    {

        if (IsOn)
        {

            targetHorizontalPosition = PageArray[0];
        
        }
    
    
    }
    public void TurnPage2(bool IsOn)
    {

        if (IsOn)
        {

            targetHorizontalPosition = PageArray[1];

        }


    }




}
