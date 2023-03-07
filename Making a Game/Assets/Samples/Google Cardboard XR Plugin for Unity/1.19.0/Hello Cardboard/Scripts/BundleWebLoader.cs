using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using System.Diagnostics;
using System.Collections.Specialized;

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
    public int MapNumber;
    public string nowEpc;

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
        Moving = false;
        Direction = "";
        MapNumber = GameObject.Find("Character").GetComponent<Character>().MapNumber; 
        nowEpc = "";

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
                //UnityEngine.Debug.Log("LastEpc" + lastEpc);
                //UnityEngine.Debug.Log("EpcName"+ rfidMessenger.rfidTag.EpcName);
                //UnityEngine.Debug.Log("Change Epc");
                //UnityEngine.Debug.Log("BundleURL"+rfidMessenger.rfidTag.BundleUrl);

                if (bundleUrl == "" && rfidMessenger.rfidTag.BundleUrl != null)
                {
                    bundleUrl = rfidMessenger.rfidTag.BundleUrl;
                    UnityEngine.Debug.Log("BundleURL set to " + bundleUrl);
                }
                if (bundleUrl != "")
                {
                    UnityEngine.Debug.Log(rfidMessenger.rfidTag.EpcName);
                    string NowName = rfidMessenger.rfidTag.AssetName;
                    UnityEngine.Debug.Log("Hello: " + NowName);
                    if (NowName != lastTag)
                    {
                        UnityEngine.Debug.Log("Break ");
                        if(lastEpc!= "")
                        {
                            MapNumber = GameObject.Find("Character").GetComponent<Character>().MapNumber;
                            Break(MapNumber, lastEpc,lastTag);
                        }
                    }
                    StartCoroutine(Load(rfidMessenger.rfidTag.AssetName));

                    nowEpc = rfidMessenger.rfidTag.EpcName;

                    GameObject.Find("LoadPrefabs").GetComponent<CreatePrefabs>().creating = true;


                    if (rfidMessenger.rfidTag.EpcName == "0009")
                    {
                        Direction = lastEpc;
                        UnityEngine.Debug.Log("Direction: " + Direction);
                        Moving = true;
                    }
                    lastTag = NowName;
                    lastEpc = rfidMessenger.rfidTag.EpcName;
                }

            }
           
            //}

        }   
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

        //player = GameObject.Find("Character");
        //playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, 0); //获取角色（摄像机）当前位置
        //更改物体位置
       // loadedAsset.transform.position = new Vector3(playerPosition.x + loadedAsset.transform.position.x, playerPosition.y+ loadedAsset.transform.position.y, 0);
        
        Instantiate(loadedAsset);

        //根据角色位置调整生成物体的位置
        //remoteAssetBundle.Unload(false);

    }

    public void Break(int map, string epc,string name)
    {
        //UnityEngine.Debug.Log("EPC:" + epc +";");
        int epcN = int.Parse(epc);
        string a = map.ToString();
        string b = epcN.ToString();
        string objName1 = a + b + "(Clone)";
        string objName2 = name + "(Clone)";
        UnityEngine.Debug.Log("Break:" +objName1+ ";");
        UnityEngine.Debug.Log("Break:" + objName2 + ";");
        GameObject obj1 = GameObject.Find(objName1);
        GameObject obj2 = GameObject.Find(objName2);
        Destroy(obj1);
        Destroy(obj2);
    }

}
