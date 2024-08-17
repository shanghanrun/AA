using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private bool isPinned = false;
    private bool isLaunched = false; // 마우스 클릭으로 발사했는지
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()  // FixedUpdate는 deltaTime 고정됨
    {
        if(isPinned == false && isLaunched){
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        isPinned = true;

        if(other.gameObject.tag == "Target"){
            //GameObject childObject = transform.Find("Square").gameObject; // 이 방법도 있고,
            GameObject childObject = transform.GetChild(0).gameObject; // GetChild에는 index

            // Square 게임오브젝트를 활성화 비활성화
            childObject.SetActive(true);

            //SpriteRender를 활성화, 비활성화
            // SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>();
            // childSprite.enabled = true;

            transform.SetParent(other.gameObject.transform);

            GameManager.instance.DecreaseGoal();
        } else if(other.gameObject.tag =="Pin"){
            GameManager.instance.SetGameOver(false);
        }
    }

    public void Launch(){
        isLaunched = true;
    }
}
