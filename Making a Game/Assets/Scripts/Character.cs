using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string Direction;
    public Boolean Moving;
    public int MapNumber;//当前所在地图，从编号0开始
    public int[] Map;//按顺序存储正确方向数字

    //public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed)


    //移动相关变量
    public Rigidbody2D rb;
    public float horizontalMove; //水平移动
    public float verticalMove;//竖直移动
    public float speed = 1.0f; //速度


    public int frameNumber;//当前所处帧数
    public int frameSum;//移动所耗帧数


    // Start is called before the first frame update
    void Start()
    {
        Direction = "";
        Moving = false;
        MapNumber = 0;

        //确定地图上正确的路线
        Map = new int[5] { 1, 1, 1, 1, 1 };

        //绑定character的rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        frameNumber = 0;
        frameSum = 500;
    }

    // Update is called once per frame
    void Update()
    {
        //检测是否需要移动
        Moving = GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Moving;

        //移动代码
        if (Moving)
        {
            Direction = GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Direction; //获取移动方位
            int direction = int.Parse(Direction); //String转换成数字
            //UnityEngine.Debug.Log("dddddd"+direction);//测试用

            if (direction == Map[MapNumber])
            {
                MovingNext(direction);//向下一个地图走
                frameNumber++;
            }
            else
            {
                MovingStill(direction,frameNumber);//仍停留在本地图
                frameNumber++;
            }

            if(frameNumber > frameSum)
            {
                if(direction == Map[MapNumber])
                {
                    MapNumber += 1;
                }
                GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Moving = false;
                frameNumber = 0;
            }

            //考虑下Epc数值归零（？
        }

        //完成移动之后把下面这句话加进去
        //GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Moving = false;
    }

    void MovingNext(int d)
    {
        if(d == 1)
           {
            //UnityEngine.Debug.Log("Moving!!!!!" );
            float X = -10f;//移动总X
            float Y = 5f;//移动总Y
            float deltaX = X/frameSum;
            float deltaY = Y/frameSum;
            transform.position += new Vector3(deltaX, deltaY , 0);
            }
        /*
            if (d == 1)
            {
                horizontalMove = -38.4f;
                verticalMove = 21.6f;
            //到达后停下
            }
            if (d == 2)
            {
                horizontalMove = 0;
                verticalMove = 21.6f;
            }
            if (d == 3)
            {
                horizontalMove = 38.4f;
                verticalMove = 21.6f;
            }
            if (d == 4)
            {
                horizontalMove = -38.4f;
                verticalMove = 0;
            }
            if (d == 5)
            {
                horizontalMove = 38.4f;
                verticalMove = 0;
            }
            if (d == 6)
            {
                horizontalMove = -38.4f;
                verticalMove = -21.6f;
            }
            if (d == 7)
            {
                horizontalMove = 0;
                verticalMove = -21.6f;
            }
            if (d == 8)
            {
                horizontalMove = 38.4f;
                verticalMove = -21.6f;
            }

        
            rb.velocity = new Vector2(horizontalMove * speed, verticalMove * speed);
            */
        
        
        

        //另一种移动的写法
       /* if (d == 1)
        {
            targetposition = new Vector3(rb.transform.position.x - 67.2f, rb.transform.position.y+37.8f,0);
            rb.transform.position = Vector3.MoveTowards(rb.transform.position, targetposition, speed);
            UnityEngine.Debug.Log("move to 1.");
        }*/
    }


    //d指方向，f指目前的帧数
    void MovingStill(int d, int f)
    {

    }
}
