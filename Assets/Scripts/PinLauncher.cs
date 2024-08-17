using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject pinObject;

    private Pin currentPin;

    void Start()
    {
        PreparePin();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && currentPin !=null
            && GameManager.instance.isGameOver == false){ // 0 왼쪽마우스버튼
            currentPin.Launch();
            currentPin = null;
            Invoke("PreparePin", 0.1f);
        }
    }
    void PreparePin(){
        // GameObject pin = Instantiate(pinObject, transform.position, Quaternion.identity);
        // currentPin = pin.GetComponent<Pin>();

        if (GameManager.instance.isGameOver == false){  
            GameObject pin = Instantiate(pinObject,transform.position,Quaternion.identity);
            currentPin = pin.GetComponent<Pin>();  
        }

    }
}
