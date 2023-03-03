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
    public UnityWebRequest webBundle;
    public AssetBundle remoteAssetBundle;
    //public Regex rx = new Regex(@"EPC:(\S+)"); //Regular expression to match RFID tag's EPC in each RFID data.
    //public MatchCollection tagEPC;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Load());
        rfidMessenger = GameObject.Find("UDPMessenger").GetComponent<UDPMessenger>();
        if (rfidMessenger == null)
        {
            UnityEngine.Debug.LogError("Failed to find RFID Messenger!");
        }

        bundleUrl = ""; //The actual asset bundle url will be contained from RFID data.
        lastTag = "";
        lastEpc = "";
        //loaderCalled = false;
    }

    void Update()
    {
        //tagEPC = rx.Matches(rfidMessenger.rfidData);   //Extract RFID tag EPC in each data
        //foreach (Match tag in tagEPC)
        //{
        //Debug.Log(tag);
        //UnityEngine.Debug.Log(rfidMessenger.rfidTag.EpcName);
        if (rfidMessenger.rfidTag.EpcName != lastEpc && rfidMessenger.rfidTag.AssetName != "")
        {
            if (bundleUrl == "" && rfidMessenger.rfidTag.BundleUrl != null)
            {
                bundleUrl = rfidMessenger.rfidTag.BundleUrl;
                //Debug.Log("BundleURL set to " + bundleUrl);
            }
            if (bundleUrl != "")
            {
               string NowName = rfidMessenger.rfidTag.AssetName;
                UnityEngine.Debug.Log("Hello: " + NowName);
                if (NowName != lastTag)
                {
                    UnityEngine.Debug.Log("Break ");
                    Break(lastTag);
                }
                StartCoroutine(Load(rfidMessenger.rfidTag.AssetName));
                lastTag = NowName;
                lastEpc = rfidMessenger.rfidTag.EpcName;
            }
        }
        //}

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
        Destroy(obj, .5f);
    }

}
