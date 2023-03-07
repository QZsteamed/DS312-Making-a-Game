using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextEditing : MonoBehaviour
{

    public TextMeshProUGUI Text;
    public int MapNumber;
    public Boolean Moving;
    public Boolean Playing;

    // Start is called before the first frame update
    void Start()
    {
        Text = transform.GetComponent<TextMeshProUGUI>();
        Moving = GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Moving;
        MapNumber = GameObject.Find("Character").GetComponent<Character>().MapNumber;

        Playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        Moving = GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Moving;
        MapNumber = GameObject.Find("Character").GetComponent<Character>().MapNumber;

        //UnityEngine.Debug.Log("Moving:" + Moving + "MapNumber:" + MapNumber);//������
        //Text = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();

        if (Moving)
        {
            //�ƶ���������ʾ������
            if(MapNumber == 0)
            {
                Text.text = "";
            }
            else if(MapNumber == 1)
            {
                Text.text = "";
            }
            else if (MapNumber == 2)
            {
                Text.text = "";
            }
            else if (MapNumber == 3)
            {
                AudioManager.audioManager.puzzleAudio1Stop();
                Text.text = "";
            }
            else if (MapNumber == 4)
            {
                Text.text = "";
            }
            else if (MapNumber == 5)
            {
                Text.text = "";
            }
            else if (MapNumber == 6)
            {
                AudioManager.audioManager.puzzleAudio2Stop();
                Text.text = "";
            }
            else if (MapNumber == 7)
            {
                Text.text = "";
            }
            else if (MapNumber == 8)
            {
                Text.text = "";
            }
            else if (MapNumber == 9)
            {
                Text.text = "";
            }
            else if (MapNumber == 10)
            {
                Text.text = "";
            }
            else if (MapNumber == 11)
            {
                Text.text = "HELP������ʲô��˼��";
            }
            else if (MapNumber == 12)
            {
                AudioManager.audioManager.puzzleAudio3Stop();
                Text.text = "";
            }
            else if (MapNumber == 13)
            {
                Text.text = "";
            }
            else if (MapNumber == 14)
            {
                AudioManager.audioManager.puzzleAudio4Stop();
                Text.text = "";
            }
            else if (MapNumber == 15)
            {
                Text.text = "";
            }

        }
        else
        {
            //���ƶ���������ʾ������
            if(MapNumber == 0)
            {
                Text.text = "������һ�����롭����";
            }
            else if (MapNumber == 1)
            {
                Text.text = "�����Ǻ������������ˡ�����";
            }
            else if (MapNumber == 2)
            {
                Text.text = "ÿ ?0 �����һ����Ϊ��ɱ��ʧȥ������";
            }
            else if (MapNumber == 3)
            {
                if (!Playing)
                {
                    AudioManager.audioManager.puzzleAudio1();
                    Playing = true;
                }
                Text.text = "";
            }
            else if (MapNumber == 4)
            {
                Text.text = "";
            }
            else if (MapNumber == 5)
            {
                Text.text = "Ŀǰ���� ?0 % ���ۺ�ҽԺû�о���ơ�";
            }
            else if (MapNumber == 6)
            {
                if(!Playing)
                {
                    AudioManager.audioManager.puzzleAudio2();
                    Playing = true;
                }
                Text.text = "";
            }
            else if (MapNumber == 7)
            {
                Text.text = "����֢����������ÿ������ ?0% ��";
            }
            else if (MapNumber == 8)
            {
                Text.text = "_ _ _ _";
            }
            else if (MapNumber == 9)
            {
                Text.text = "_ E _ _";
            }
            else if (MapNumber == 10)
            {
                Text.text = "_ E _ P";
            }
            else if (MapNumber == 11)
            {
                Text.text = "_ E L P";
            }
            else if (MapNumber == 12)
            {
                if (!Playing)
                {
                    AudioManager.audioManager.puzzleAudio3();
                    Playing = true;
                }
                Text.text = "";
            }
            else if (MapNumber == 13)
            {
                Text.text = "";
            }
            else if (MapNumber == 14)
            {
                if (!Playing)
                {
                    AudioManager.audioManager.puzzleAudio4();
                    Playing = true;
                }
                Text.text = "";
            }
            else if (MapNumber == 15)
            {
                Text.text = "";
            }

            Text = transform.GetComponent<TextMeshProUGUI>();
        }
    }
}
