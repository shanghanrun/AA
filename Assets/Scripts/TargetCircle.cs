using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = -30f; //음수 시계반향회전 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed * Time.deltaTime);
    }
}
