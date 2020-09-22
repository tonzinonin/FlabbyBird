using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;//表示数组初始长度的值。
    public GameObject columnPrefab;//实例化的对象
    public float spwanRate = 4f;//在玩家面前从对象池放置新柱子的时间间隔。
    public float columnMin = -1f;
    public float columnMax = 3.5f;//以垂直随机偏移量定位柱子

    private GameObject[] columns;//柱子数组。
    private Vector2 ObjectPoolPosition = new Vector2(-15f, -25f);//一个屏幕外的位置
    private float timeSinceLastSpawned; //储存自上一次在玩家面前放置一个柱子以来，已经过了多少时间。
    private float spawnXPosition = 10f;
    private int currentColumn = 0;//跟踪正在重新定义数组中的柱子

    void Start()
    {
        columns = new GameObject[columnPoolSize];//用5个空对象制作了一个新的空数组游戏对象
        for (int i = 0; i < columnPoolSize; i++)
        {   //循环遍历我们索引的每一个对象，实例化Prefab,实例化的位置是ObjectPoolPosition,Quaternion.identity设置预制体的旋转
            columns[i] = (GameObject) Instantiate(columnPrefab,ObjectPoolPosition,Quaternion.identity);
            //实例化一个对象为游戏对象，储存在数组中
        }
    }

    void Update()//计时器
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.GameOver == false && timeSinceLastSpawned >= spwanRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);//生成柱子
            columns [currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            //生成了一个固定的x坐标，随机的y坐标；
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
