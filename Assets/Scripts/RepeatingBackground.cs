using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();//引入碰撞体
        groundHorizontalLength = groundCollider.size.x;//获得x轴的大小
    }
     
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)//检查是否需要重新定位
        {
            RepositionBackground ();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2, 0);
        //在重新定位它的时候我们向前迈进了多少距离。
        transform.position = (Vector2) transform.position + groundOffset;//计算移动多远

    }
}
