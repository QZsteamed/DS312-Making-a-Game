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
    public int MapNumber;//��ǰ���ڵ�ͼ���ӱ��0��ʼ
    public int[] Map;//��˳��洢��ȷ��������

    //public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed)


    //�ƶ���ر���
    public Rigidbody2D rb;
    public float horizontalMove; //ˮƽ�ƶ�
    public float verticalMove;//��ֱ�ƶ�
    public float speed = 1.0f; //�ٶ�


    public int frameNumber;//��ǰ����֡��
    public int frameSum;//�ƶ�����֡��


    // Start is called before the first frame update
    void Start()
    {
        Direction = "";
        Moving = false;
        MapNumber = 0;

        //ȷ����ͼ����ȷ��·��
        Map = new int[17] { 3, 5, 7, 5, 7, 3, 3, 8, 6, 6, 6, 7, 1, 1, 1, 2, 0 };

        //��character��rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        frameNumber = 0;
        frameSum = 5000;//�����ٶ�
    }

    // Update is called once per frame
    void Update()
    {
        //����Ƿ���Ҫ�ƶ�
        Moving = GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Moving;

        //�ƶ�����
        if (Moving)
        {
            Direction = GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Direction; //��ȡ�ƶ���λ
            int direction = int.Parse(Direction); //Stringת��������
            //UnityEngine.Debug.Log("dddddd"+direction);//������

            if (direction == Map[MapNumber])
            {
                //UnityEngine.Debug.Log("MovingNext" );//������
                MovingNext(direction);//����һ����ͼ��
                frameNumber++;
            }
            else
            {
                //UnityEngine.Debug.Log("MovingStill");//������
                MovingStill(direction,frameNumber);//��ͣ���ڱ���ͼ
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
                    //���ٶ�Ӧ��Ʒ
                    string objName = "Item";
                    string s1 = MapNumber.ToString();
                    objName = objName + s1;
                    GameObject obj = GameObject.Find(objName);
                    Destroy(obj);
                    */

                    //���һ�£��Ƿ�����Ʒ
                    if((((MapNumber == 3 || MapNumber == 6) || MapNumber == 9) || MapNumber == 12) || MapNumber == 14)
                    {
                        int random;
                        float origin = GameObject.Find("Number").GetComponent<TextController>().number;
                        random = UnityEngine.Random.Range(1,101);
                        //���ǰѸ�������ӻ����Ӹ�Ԥ���壿)
                        UnityEngine.Debug.Log("Random:" + random);
                        if (random <= 20)
                        {
                            //����ɹ�
                            if(origin <= 15)
                            {
                                //�������ɹ�

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

            //������Epc��ֵ���㣨��
        }

        //����ƶ�֮���������仰�ӽ�ȥ
        //GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Moving = false;
    }

    void MovingNext(int d)
    {
        float SumX = 38.4f;
        float SumY = 21.6f;
        if(d == 1)
           {
            //UnityEngine.Debug.Log("Moving!!!!!" );
            float X = -SumX;//�ƶ���X
            float Y = SumY;//�ƶ���Y
            float deltaX = X/frameSum;
            float deltaY = Y/frameSum;
            transform.position += new Vector3(deltaX, deltaY , 0);
            }
        if (d == 2)
        {
            float X = 0;//�ƶ���X
            float Y = SumY;//�ƶ���Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 3)
        {
            float X = SumX;//�ƶ���X
            float Y = SumY;//�ƶ���Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 4)
        {
            float X = -SumX;//�ƶ���X
            float Y = 0;//�ƶ���Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 5)
        {
            float X = SumX;//�ƶ���X
            float Y =0;//�ƶ���Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 6)
        {
            float X = -SumX;//�ƶ���X
            float Y = -SumY;//�ƶ���Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 7)
        {
            float X = 0;//�ƶ���X
            float Y = -SumY;//�ƶ���Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }
        if (d == 8)
        {
            float X = SumX;//�ƶ���X
            float Y = -SumY;//�ƶ���Y
            float deltaX = X / frameSum;
            float deltaY = Y / frameSum;
            transform.position += new Vector3(deltaX, deltaY, 0);
        }

    }


    //dָ����fָĿǰ��֡��
    void MovingStill(int d, int f)
    {
        float SumX = 38.4f;
        float SumY = 21.6f;
        //��������
        if (d == 1)
        {
            float X = -SumX;//�ƶ���X
            float Y = SumY;//�ƶ���Y
            float deltaX1 = X / frameSum;//˲��ǰ�ƶ�x
            float deltaY1 = Y / frameSum;//˲��ǰ�ƶ�y
            float deltaX2 = X / frameSum;//˲�ƺ��ƶ�x
            float deltaY2 = Y / frameSum;//˲�ƺ��ƶ�y
            //��ʵ��x��y��framesum������߶����Զ�������д��������������&��Ȼ����һ������Ϊ���Լ�����������Էֿ�д�ˡ�
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
            float X = 0;//�ƶ���X
            float Y = SumY;//�ƶ���Y
            float deltaX1 = X / frameSum;//˲��ǰ�ƶ�x
            float deltaY1 = Y / frameSum;//˲��ǰ�ƶ�y
            float deltaX2 = X / frameSum;//˲�ƺ��ƶ�x
            float deltaY2 = Y / frameSum;//˲�ƺ��ƶ�y
            //��ʵ��x��y��framesum������߶����Զ�������д��������������&��Ȼ����һ������Ϊ���Լ�����������Էֿ�д�ˡ�
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
            float X = SumX;//�ƶ���X
            float Y = SumY;//�ƶ���Y
            float deltaX1 = X / frameSum;//˲��ǰ�ƶ�x
            float deltaY1 = Y / frameSum;//˲��ǰ�ƶ�y
            float deltaX2 = X / frameSum;//˲�ƺ��ƶ�x
            float deltaY2 = Y / frameSum;//˲�ƺ��ƶ�y
            //��ʵ��x��y��framesum������߶����Զ�������д��������������&��Ȼ����һ������Ϊ���Լ�����������Էֿ�д�ˡ�
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
            float X = -SumX;//�ƶ���X
            float Y = 0;//�ƶ���Y
            float deltaX1 = X / frameSum;//˲��ǰ�ƶ�x
            float deltaY1 = Y / frameSum;//˲��ǰ�ƶ�y
            float deltaX2 = X / frameSum;//˲�ƺ��ƶ�x
            float deltaY2 = Y / frameSum;//˲�ƺ��ƶ�y
            //��ʵ��x��y��framesum������߶����Զ�������д��������������&��Ȼ����һ������Ϊ���Լ�����������Էֿ�д�ˡ�
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
            float X = SumX;//�ƶ���X
            float Y = 0;//�ƶ���Y
            float deltaX1 = X / frameSum;//˲��ǰ�ƶ�x
            float deltaY1 = Y / frameSum;//˲��ǰ�ƶ�y
            float deltaX2 = X / frameSum;//˲�ƺ��ƶ�x
            float deltaY2 = Y / frameSum;//˲�ƺ��ƶ�y
            //��ʵ��x��y��framesum������߶����Զ�������д��������������&��Ȼ����һ������Ϊ���Լ�����������Էֿ�д�ˡ�
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
            float X = -SumX;//�ƶ���X
            float Y = -SumY;//�ƶ���Y
            float deltaX1 = X / frameSum;//˲��ǰ�ƶ�x
            float deltaY1 = Y / frameSum;//˲��ǰ�ƶ�y
            float deltaX2 = X / frameSum;//˲�ƺ��ƶ�x
            float deltaY2 = Y / frameSum;//˲�ƺ��ƶ�y
            //��ʵ��x��y��framesum������߶����Զ�������д��������������&��Ȼ����һ������Ϊ���Լ�����������Էֿ�д�ˡ�
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
            float X = 0;//�ƶ���X
            float Y = -SumY;//�ƶ���Y
            float deltaX1 = X / frameSum;//˲��ǰ�ƶ�x
            float deltaY1 = Y / frameSum;//˲��ǰ�ƶ�y
            float deltaX2 = X / frameSum;//˲�ƺ��ƶ�x
            float deltaY2 = Y / frameSum;//˲�ƺ��ƶ�y
            //��ʵ��x��y��framesum������߶����Զ�������д��������������&��Ȼ����һ������Ϊ���Լ�����������Էֿ�д�ˡ�
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
            float X = SumX;//�ƶ���X
            float Y = -SumY;//�ƶ���Y
            float deltaX1 = X / frameSum;//˲��ǰ�ƶ�x
            float deltaY1 = Y / frameSum;//˲��ǰ�ƶ�y
            float deltaX2 = X / frameSum;//˲�ƺ��ƶ�x
            float deltaY2 = Y / frameSum;//˲�ƺ��ƶ�y
            //��ʵ��x��y��framesum������߶����Զ�������д��������������&��Ȼ����һ������Ϊ���Լ�����������Էֿ�д�ˡ�
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
