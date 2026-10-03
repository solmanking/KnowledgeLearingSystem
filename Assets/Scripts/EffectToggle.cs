using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectToggle : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject IsOnGameObject;
    public GameObject IsOffGameObject;
    private Toggle Toggle;
    void Start()
    {
        Toggle = GetComponent<Toggle>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        OnvalueChange(Toggle.isOn);
    }

    public void OnvalueChange(bool isOn)
    {
        IsOnGameObject.SetActive(isOn);
        IsOffGameObject.SetActive(!isOn);
    
    }
}
