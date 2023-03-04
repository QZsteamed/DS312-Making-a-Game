using System;
using System.Collections;
using System.Collections.Generic;
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
        Map = new int[5] { 1, 1, 1, 1, 1 };

        //��character��rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        frameNumber = 0;
        frameSum = 500;
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
                MovingNext(direction);//����һ����ͼ��
                frameNumber++;
            }
            else
            {
                MovingStill(direction,frameNumber);//��ͣ���ڱ���ͼ
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

            //������Epc��ֵ���㣨��
        }

        //����ƶ�֮���������仰�ӽ�ȥ
        //GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Moving = false;
    }

    void MovingNext(int d)
    {
        if(d == 1)
           {
            //UnityEngine.Debug.Log("Moving!!!!!" );
            float X = -10f;//�ƶ���X
            float Y = 5f;//�ƶ���Y
            float deltaX = X/frameSum;
            float deltaY = Y/frameSum;
            transform.position += new Vector3(deltaX, deltaY , 0);
            }
        /*
            if (d == 1)
            {
                horizontalMove = -38.4f;
                verticalMove = 21.6f;
            //�����ͣ��
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
        
        
        

        //��һ���ƶ���д��
       /* if (d == 1)
        {
            targetposition = new Vector3(rb.transform.position.x - 67.2f, rb.transform.position.y+37.8f,0);
            rb.transform.position = Vector3.MoveTowards(rb.transform.position, targetposition, speed);
            UnityEngine.Debug.Log("move to 1.");
        }*/
    }


    //dָ����fָĿǰ��֡��
    void MovingStill(int d, int f)
    {

    }
}
