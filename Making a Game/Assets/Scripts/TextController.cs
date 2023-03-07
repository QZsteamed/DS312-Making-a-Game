using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class TextController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI Text;
    
    // Start is called before the first frame update
    public float number;
    public int count;
    void Start()
    {
        spriteRenderer = GameObject.Find("Character").GetComponent<SpriteRenderer>();
        Text = transform.GetComponent<TextMeshProUGUI>();
        number = 30.00f;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count > 300)
        {   
            if(number >= 99.99f)
            {
                number = 100;
                //½áÊø£¬Ê§°Ü
                //AudioManager.audioManager.EndAudio();
                //AudioManager.audioManager.BackgroundStop();
                SceneManager.LoadScene(2);
            }
            number += 0.01f;
            float colorNumber = (100 - number)/100;
            //UnityEngine.Debug.Log("Color:" + colorNumber);
            spriteRenderer.color = new Color(colorNumber, colorNumber, colorNumber, 1);
            string Num = number.ToString("0.00");
            //UnityEngine.Debug.Log("Increase Number");
            Text.text = Num + "%";
            count = 0;
        }
    }



}
