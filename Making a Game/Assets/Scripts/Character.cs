using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
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
        Map = new int[17] { 3, 5, 7, 5, 7, 3, 3, 8, 6, 6, 6, 7, 1, 1, 1, 2, 0 };

        //绑定character的rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        frameNumber = 0;
        frameSum = 5000;//决定速度
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
                //UnityEngine.Debug.Log("MovingNext" );//测试用
                MovingNext(direction);//向下一个地图走
                frameNumber++;
            }
            else
            {
                //UnityEngine.Debug.Log("MovingStill");//测试用
                MovingStill(direction,frameNumber);//仍停留在本地图
                frameNumber++;
            }

            if(frameNumber > frameSum)
            {
                if(direction == Map[MapNumber])
                {
                    MapNumber += 1;
                    if(MapNumber == 16)
                    {
                        MapNumber = 0;
                    }

                    /*
                    //销毁对应物品
                    string objName = "Item";
                    string s1 = MapNumber.ToString();
                    objName = objName + s1;
                    GameObject obj = GameObject.Find(objName);
                    Destroy(obj);
                    */

                    //随机一下，是否获得物品
                    if((((MapNumber == 3 || MapNumber == 6) || MapNumber == 9) || MapNumber == 12) || MapNumber == 14)
                    {
                        int random;
                        float origin = GameObject.Find("Number").GetComponent<TextController>().number;
                        random = UnityEngine.Random.Range(1,101);
                        //考虑把该随机可视化（加个预制体？)
                        UnityEngine.Debug.Log("Random:" + random);
                        if (random <= 20)
                        {
                            //随机成功
                            if(origin <= 15)
                            {
                                //结束，成功

                            }
                            else
                            {
                                GameObject.Find("Number").GetComponent<TextController>().number -= 15;
                            }
                            
                        }

                    }



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
        float SumX = 38.4f;
        float SumY = 21.6f;
        if(d == 1)
           {
            //UnityEngine.Debug.Log("Moving!!!!!" );
            float X = -SumX;//移动总X
            float Y = SumY;//移动总Y
            float deltaX = X/frameSum;
            float deltaY = Y/frameSum;
            transform.position += new Vector3(deltaX, deltaY , 0);
            }
        if (d == 2)
        {
            float X = 0;//移动总X
            float Y = SumY;//移动总Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 3)
        {
            float X = SumX;//移动总X
            float Y = SumY;//移动总Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 4)
        {
            float X = -SumX;//移动总X
            float Y = 0;//移动总Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 5)
        {
            float X = SumX;//移动总X
            float Y =0;//移动总Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 6)
        {
            float X = -SumX;//移动总X
            float Y = -SumY;//移动总Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 7)
        {
            float X = 0;//移动总X
            float Y = -SumY;//移动总Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 8)
        {
            float X = SumX;//移动总X
            float Y = -SumY;//移动总Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }

    }


    //d指方向，f指目前的帧数
    void MovingStill(int d, int f)
    {
        float SumX = 38.4f;
        float SumY = 21.6f;
        //暴力啊好
        if (d == 1)
        {
            float X = -SumX;//移动总X
            float Y = SumY;//移动总Y
            float deltaX1 = X / frameSum;//瞬移前移动x
            float deltaY1 = Y / frameSum;//瞬移前移动y
            float deltaX2 = X / frameSum;//瞬移后移动x
            float deltaY2 = Y / frameSum;//瞬移后移动y
            //其实是x，y和framesum在这里边都除以二了于是写出来还是这样。&虽然长得一样但是为了自己能想清楚所以分开写了。
            if (f < (frameSum / 2))
            {
                transform.position += new Vector3(deltaX1, deltaY1, 0);
            }
            else if (f == (frameSum / 2))
            {
                transform.position += new Vector3(-X, -Y, 0);
            }
            else if (f > (frameSum / 2))
            {
                transform.position += new Vector3(deltaX2, deltaY2, 0);
            }
        }
        if (d == 2)
        {
            float X = 0;//移动总X
            float Y = SumY;//移动总Y
            float deltaX1 = X / frameSum;//瞬移前移动x
            float deltaY1 = Y / frameSum;//瞬移前移动y
            float deltaX2 = X / frameSum;//瞬移后移动x
            float deltaY2 = Y / frameSum;//瞬移后移动y
            //其实是x，y和framesum在这里边都除以二了于是写出来还是这样。&虽然长得一样但是为了自己能想清楚所以分开写了。
            if (f < frameSum / 2)
            {
                transform.position += new Vector3(deltaX1, deltaY1, 0);
            }
            else if (f == frameSum / 2)
            {
                transform.position += new Vector3(-X, -Y, 0);
            }
            else if(f>frameSum/2)
            {
                transform.position += new Vector3(deltaX2, deltaY2, 0);
            }
        }
        if (d == 3)
        {
            float X = SumX;//移动总X
            float Y = SumY;//移动总Y
            float deltaX1 = X / frameSum;//瞬移前移动x
            float deltaY1 = Y / frameSum;//瞬移前移动y
            float deltaX2 = X / frameSum;//瞬移后移动x
            float deltaY2 = Y / frameSum;//瞬移后移动y
            //其实是x，y和framesum在这里边都除以二了于是写出来还是这样。&虽然长得一样但是为了自己能想清楚所以分开写了。
            if (f < frameSum / 2)
            {
                transform.position += new Vector3(deltaX1, deltaY1, 0);
            }
            else if (f == frameSum / 2)
            {
                transform.position += new Vector3(-X, -Y, 0);
            }
            else if (f > frameSum / 2)
            {
                transform.position += new Vector3(deltaX2, deltaY2, 0);
            }
        }
        if (d == 4)
        {
            float X = -SumX;//移动总X
            float Y = 0;//移动总Y
            float deltaX1 = X / frameSum;//瞬移前移动x
            float deltaY1 = Y / frameSum;//瞬移前移动y
            float deltaX2 = X / frameSum;//瞬移后移动x
            float deltaY2 = Y / frameSum;//瞬移后移动y
            //其实是x，y和framesum在这里边都除以二了于是写出来还是这样。&虽然长得一样但是为了自己能想清楚所以分开写了。
            if (f < frameSum / 2)
            {
                transform.position += new Vector3(deltaX1, deltaY1, 0);
            }
            else if (f == frameSum / 2)
            {
                transform.position += new Vector3(-X, -Y, 0);
            }
            else if (f > frameSum / 2)
            {
                transform.position += new Vector3(deltaX2, deltaY2, 0);
            }
        }
        if (d == 5)
        {
            float X = SumX;//移动总X
            float Y = 0;//移动总Y
            float deltaX1 = X / frameSum;//瞬移前移动x
            float deltaY1 = Y / frameSum;//瞬移前移动y
            float deltaX2 = X / frameSum;//瞬移后移动x
            float deltaY2 = Y / frameSum;//瞬移后移动y
            //其实是x，y和framesum在这里边都除以二了于是写出来还是这样。&虽然长得一样但是为了自己能想清楚所以分开写了。
            if (f < frameSum / 2)
            {
                transform.position += new Vector3(deltaX1, deltaY1, 0);
            }
            else if (f == frameSum / 2)
            {
                transform.position += new Vector3(-X, -Y, 0);
            }
            else if (f > frameSum / 2)
            {
                transform.position += new Vector3(deltaX2, deltaY2, 0);
            }
        }
        if (d == 6)
        {
            float X = -SumX;//移动总X
            float Y = -SumY;//移动总Y
            float deltaX1 = X / frameSum;//瞬移前移动x
            float deltaY1 = Y / frameSum;//瞬移前移动y
            float deltaX2 = X / frameSum;//瞬移后移动x
            float deltaY2 = Y / frameSum;//瞬移后移动y
            //其实是x，y和framesum在这里边都除以二了于是写出来还是这样。&虽然长得一样但是为了自己能想清楚所以分开写了。
            if (f < frameSum / 2)
            {
                transform.position += new Vector3(deltaX1, deltaY1, 0);
            }
            else if (f == frameSum / 2)
            {
                transform.position += new Vector3(-X, -Y, 0);
            }
            else if (f > frameSum / 2)
            {
                transform.position += new Vector3(deltaX2, deltaY2, 0);
            }
        }
        if (d == 7)
        {
            float X = 0;//移动总X
            float Y = -SumY;//移动总Y
            float deltaX1 = X / frameSum;//瞬移前移动x
            float deltaY1 = Y / frameSum;//瞬移前移动y
            float deltaX2 = X / frameSum;//瞬移后移动x
            float deltaY2 = Y / frameSum;//瞬移后移动y
            //其实是x，y和framesum在这里边都除以二了于是写出来还是这样。&虽然长得一样但是为了自己能想清楚所以分开写了。
            if (f < frameSum / 2)
            {
                transform.position += new Vector3(deltaX1, deltaY1, 0);
            }
            else if (f == frameSum / 2)
            {
                transform.position += new Vector3(-X, -Y, 0);
            }
            else if (f > frameSum / 2)
            {
                transform.position += new Vector3(deltaX2, deltaY2, 0);
            }
        }
        if (d == 8)
        {
            float X = SumX;//移动总X
            float Y = -SumY;//移动总Y
            float deltaX1 = X / frameSum;//瞬移前移动x
            float deltaY1 = Y / frameSum;//瞬移前移动y
            float deltaX2 = X / frameSum;//瞬移后移动x
            float deltaY2 = Y / frameSum;//瞬移后移动y
            //其实是x，y和framesum在这里边都除以二了于是写出来还是这样。&虽然长得一样但是为了自己能想清楚所以分开写了。
            if (f < frameSum / 2)
            {
                transform.position += new Vector3(deltaX1, deltaY1, 0);
            }
            else if (f == frameSum / 2)
            {
                transform.position += new Vector3(-X, -Y, 0);
            }
            else if (f > frameSum / 2)
            {
                transform.position += new Vector3(deltaX2, deltaY2, 0);
            }
        }
    }
}
