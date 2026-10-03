using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRotation : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider SliderBar;

    public GameObject CubeA;

    private float RotateSpeed = 90.0f;
    public float nowSpeed;


    void Start()
    {


         SliderBar = GameObject.Find("CubeSlider").GetComponent<Slider>();

          CubeA = GameObject.Find("Cube");


    }

    // Update is called once per frame
    void Update()
    {

        nowSpeed = RotateSpeed * SliderBar.value;
        RotateCube(RotateSpeed);
    }

    private void RotateCube(float Needspeed)
    {
        CubeA.transform.Rotate(Vector3.up*nowSpeed*Time.deltaTime);
    
    
    }



}
