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

    // Start is called before the first frame update
    void Start()
    {
        Text = transform.GetComponent<TextMeshProUGUI>();
        Moving = GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().Moving;
        MapNumber = GameObject.Find("Character").GetComponent<Character>().MapNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            //移动过程中显示的文字
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
                Text.text = "HELP？这是什么意思？";
            }
            else if (MapNumber == 12)
            {
                Text.text = "";
            }
            else if (MapNumber == 13)
            {
                Text.text = "";
            }
            else if (MapNumber == 14)
            {
                Text.text = "";
            }
            else if (MapNumber == 15)
            {
                Text.text = "";
            }

        }
        else
        {
            //非移动过程中显示的文字
            if(MapNumber == 0)
            {
                Text.text = "";
            }
            else if (MapNumber == 1)
            {
                Text.text = "";
            }
            else if (MapNumber == 2)
            {
                Text.text = "";
            }
            else if (MapNumber == 3)
            {
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
                Text.text = "";
            }
            else if (MapNumber == 7)
            {
                Text.text = "";
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
                Text.text = "";
            }
            else if (MapNumber == 13)
            {
                Text.text = "";
            }
            else if (MapNumber == 14)
            {
                Text.text = "";
            }
            else if (MapNumber == 15)
            {
                Text.text = "";
            }
        }
    }
}
