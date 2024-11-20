using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//給雲,地面,仙人掌使用的腳本
public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public float startPosition;
    public float endPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y);  //讓地面往左邊移動
        
        if (transform.position.x <= endPosition)
        {
            //當移動到最後的位置時
            if (gameObject.tag == "Cactus")
            {
                //仙人掌移動到場景最左邊,就摧毀它
                Destroy(gameObject);
                //不會讓整個場景都是仙人掌
            }
            else
            {
                //不是仙人掌的話(地面和雲朵)
                transform.position = new Vector2(startPosition, transform.position.y);  //回到初始位置,從頭開始
            }
        }
    }
}
