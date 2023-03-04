using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using System.Diagnostics;

public class BundleWebLoader : MonoBehaviour
{
    public string bundleUrl;
    //public string assetName = "";
    public UDPMessenger rfidMessenger;
    //public List<GameObject> loadedAsset;
    public List<String> readTags = new List<string>();
    public string lastEpc;
    public string lastTag;
    public string Direction;
    public Boolean Moving;
    public UnityWebRequest webBundle;
    public AssetBundle remoteAssetBundle;
    //public Regex rx = new Regex(@"EPC:(\S+)"); //Regular expression to match RFID tag's EPC in each RFID data.
    //public MatchCollection tagEPC;

    public GameObject background;
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Load());
        rfidMessenger = GameObject.Find("UDPMessenger").GetComponent<UDPMessenger>();
        background = GameObject.Find("Background");
        if (rfidMessenger == null)
        {
            UnityEngine.Debug.LogError("Failed to find RFID Messenger!");
        }

        bundleUrl = ""; //The actual asset bundle url will be contained from RFID data.
        lastTag = "";
        lastEpc = "";
        Moving = false;
       Direction = "";
    //loaderCalled = false;
}

    void Update()
    {
        //tagEPC = rx.Matches(rfidMessenger.rfidData);   //Extract RFID tag EPC in each data
        //foreach (Match tag in tagEPC)
        //{
        //Debug.Log(tag);
        if (!Moving)
        {
            if (rfidMessenger.rfidTag.EpcName != lastEpc && rfidMessenger.rfidTag.AssetName != "")
            {
                if (bundleUrl == "" && rfidMessenger.rfidTag.BundleUrl != null)
                {
                    bundleUrl = rfidMessenger.rfidTag.BundleUrl;
                    //Debug.Log("BundleURL set to " + bundleUrl);
                }
                if (bundleUrl != "")
                {
                    UnityEngine.Debug.Log(rfidMessenger.rfidTag.EpcName);
                    string NowName = rfidMessenger.rfidTag.AssetName;
                    UnityEngine.Debug.Log("Hello: " + NowName);
                    if (NowName != lastTag)
                    {
                        UnityEngine.Debug.Log("Break ");
                        Break(lastTag);
                    }
                    StartCoroutine(Load(rfidMessenger.rfidTag.AssetName));
                    if (rfidMessenger.rfidTag.EpcName == "0009")
                    {
                        Direction = lastEpc;
                        UnityEngine.Debug.Log("Direction: " + Direction);
                        Moving = true;
                    }
                    lastTag = NowName;
                    lastEpc = rfidMessenger.rfidTag.EpcName;
                }

                //可以这么写吗
                /*
                if(rfidMessenger.rfidTag.EpcName == "0000")
                {
                    UnityEngine.Debug.Log("move!");//果然不行，写到外面去也不行
                    Movement();

                }
                */
            }
            //}

        }   
        //试下这里Epc归零？
    }

    public IEnumerator Load(string assetName)
    {
        //Load dynamic web asset from remote web server, according to given asset name.
        if (webBundle == null)
        {
            webBundle = UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl);
            yield return webBundle.SendWebRequest();
            remoteAssetBundle = (webBundle.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        }

        if (remoteAssetBundle == null)
        {
            UnityEngine.Debug.LogError("Failed to download AssetBundle!");
            yield break;
        }

        GameObject loadedAsset = remoteAssetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(loadedAsset);

        //remoteAssetBundle.Unload(false);

    }

    public void Break(string breakobject)
    {
        string objName = breakobject + "(Clone)";
        GameObject obj = GameObject.Find(objName);
        //Destroy(obj, .5f);
        Destroy(obj);
    }

}
