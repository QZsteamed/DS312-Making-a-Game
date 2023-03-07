using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabs : MonoBehaviour
{
    public Boolean creating;
    public int MapNumber;
    public string EPC;

    public GameObject P01;
    public GameObject P02;
    public GameObject P03;
    public GameObject P04;
    public GameObject P05;
    public GameObject P06;
    public GameObject P07;
    public GameObject P08;

    public GameObject P11;
    public GameObject P12;
    public GameObject P13;
    public GameObject P14;
    public GameObject P15;
    public GameObject P16;
    public GameObject P17;
    public GameObject P18;

    public GameObject P21;
    public GameObject P22;
    public GameObject P23;
    public GameObject P24;
    public GameObject P25;
    public GameObject P26;
    public GameObject P27;
    public GameObject P28;

    public GameObject P31;
    public GameObject P32;
    public GameObject P33;
    public GameObject P34;
    public GameObject P35;
    public GameObject P36;
    public GameObject P37;
    public GameObject P38;

    public GameObject P41;
    public GameObject P42;
    public GameObject P43;
    public GameObject P44;
    public GameObject P45;
    public GameObject P46;
    public GameObject P47;
    public GameObject P48;

    public GameObject P51;
    public GameObject P52;
    public GameObject P53;
    public GameObject P54;
    public GameObject P55;
    public GameObject P56;
    public GameObject P57;
    public GameObject P58;

    public GameObject P61;
    public GameObject P62;
    public GameObject P63;
    public GameObject P64;
    public GameObject P65;
    public GameObject P66;
    public GameObject P67;
    public GameObject P68;

    public GameObject P71;
    public GameObject P72;
    public GameObject P73;
    public GameObject P74;
    public GameObject P75;
    public GameObject P76;
    public GameObject P77;
    public GameObject P78;

    public GameObject P81;
    public GameObject P82;
    public GameObject P83;
    public GameObject P84;
    public GameObject P85;
    public GameObject P86;
    public GameObject P87;
    public GameObject P88;

    public GameObject P91;
    public GameObject P92;
    public GameObject P93;
    public GameObject P94;
    public GameObject P95;
    public GameObject P96;
    public GameObject P97;
    public GameObject P98;

    public GameObject P101;
    public GameObject P102;
    public GameObject P103;
    public GameObject P104;
    public GameObject P105;
    public GameObject P106;
    public GameObject P107;
    public GameObject P108;

    public GameObject P111;
    public GameObject P112;
    public GameObject P113;
    public GameObject P114;
    public GameObject P115;
    public GameObject P116;
    public GameObject P117;
    public GameObject P118;

    public GameObject P121;
    public GameObject P122;
    public GameObject P123;
    public GameObject P124;
    public GameObject P125;
    public GameObject P126;
    public GameObject P127;
    public GameObject P128;

    public GameObject P131;
    public GameObject P132;
    public GameObject P133;
    public GameObject P134;
    public GameObject P135;
    public GameObject P136;
    public GameObject P137;
    public GameObject P138;

    public GameObject P141;
    public GameObject P142;
    public GameObject P143;
    public GameObject P144;
    public GameObject P145;
    public GameObject P146;
    public GameObject P147;
    public GameObject P148;

    public GameObject P151;
    public GameObject P152;
    public GameObject P153;
    public GameObject P154;
    public GameObject P155;
    public GameObject P156;
    public GameObject P157;
    public GameObject P158;


    // Start is called before the first frame update
    void Start()
    {
        creating = false;
        MapNumber= 0;
        EPC = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (creating)
        {
            //查找当前所在地图
           MapNumber = GameObject.Find("Character").GetComponent<Character>().MapNumber;

            //查找当前的Messenger
            EPC = GameObject.Find("AssetLoader").GetComponent<BundleWebLoader>().nowEpc;
            int EpcNumber = int.Parse(EPC);

            UnityEngine.Debug.Log("Creating "+ EpcNumber );//测试用

            if (MapNumber == 0)
            {
                if (EpcNumber == 1){GameObject.Instantiate(P01);}
                if (EpcNumber == 2){GameObject.Instantiate(P02);}
                if (EpcNumber == 3){GameObject.Instantiate(P03);}
                if (EpcNumber == 4){GameObject.Instantiate(P04);}
                if (EpcNumber == 5){GameObject.Instantiate(P05);}
                if (EpcNumber == 6){GameObject.Instantiate(P06);}
                if (EpcNumber == 7){GameObject.Instantiate(P07);}
                if (EpcNumber == 8){GameObject.Instantiate(P08);}
            }

            if (MapNumber == 1)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P11); }
                if (EpcNumber == 2) { GameObject.Instantiate(P12); }
                if (EpcNumber == 3) { GameObject.Instantiate(P13); }
                if (EpcNumber == 4) { GameObject.Instantiate(P14); }
                if (EpcNumber == 5) { GameObject.Instantiate(P15); }
                if (EpcNumber == 6) { GameObject.Instantiate(P16); }
                if (EpcNumber == 7) { GameObject.Instantiate(P17); }
                if (EpcNumber == 8) { GameObject.Instantiate(P18); }
            }

            if (MapNumber == 2)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P21); }
                if (EpcNumber == 2) { GameObject.Instantiate(P22); }
                if (EpcNumber == 3) { GameObject.Instantiate(P23); }
                if (EpcNumber == 4) { GameObject.Instantiate(P24); }
                if (EpcNumber == 5) { GameObject.Instantiate(P25); }
                if (EpcNumber == 6) { GameObject.Instantiate(P26); }
                if (EpcNumber == 7) { GameObject.Instantiate(P27); }
                if (EpcNumber == 8) { GameObject.Instantiate(P28); }
            }

            if (MapNumber == 3)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P31); }
                if (EpcNumber == 2) { GameObject.Instantiate(P32); }
                if (EpcNumber == 3) { GameObject.Instantiate(P33); }
                if (EpcNumber == 4) { GameObject.Instantiate(P34); }
                if (EpcNumber == 5) { GameObject.Instantiate(P35); }
                if (EpcNumber == 6) { GameObject.Instantiate(P36); }
                if (EpcNumber == 7) { GameObject.Instantiate(P37); }
                if (EpcNumber == 8) { GameObject.Instantiate(P38); }
            }

            if (MapNumber == 4)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P41); }
                if (EpcNumber == 2) { GameObject.Instantiate(P42); }
                if (EpcNumber == 3) { GameObject.Instantiate(P43); }
                if (EpcNumber == 4) { GameObject.Instantiate(P44); }
                if (EpcNumber == 5) { GameObject.Instantiate(P45); }
                if (EpcNumber == 6) { GameObject.Instantiate(P46); }
                if (EpcNumber == 7) { GameObject.Instantiate(P47); }
                if (EpcNumber == 8) { GameObject.Instantiate(P48); }
            }

            if (MapNumber == 5)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P51); }
                if (EpcNumber == 2) { GameObject.Instantiate(P52); }
                if (EpcNumber == 3) { GameObject.Instantiate(P53); }
                if (EpcNumber == 4) { GameObject.Instantiate(P54); }
                if (EpcNumber == 5) { GameObject.Instantiate(P55); }
                if (EpcNumber == 6) { GameObject.Instantiate(P56); }
                if (EpcNumber == 7) { GameObject.Instantiate(P57); }
                if (EpcNumber == 8) { GameObject.Instantiate(P58); }
            }

            if (MapNumber == 6)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P61); }
                if (EpcNumber == 2) { GameObject.Instantiate(P62); }
                if (EpcNumber == 3) { GameObject.Instantiate(P63); }
                if (EpcNumber == 4) { GameObject.Instantiate(P64); }
                if (EpcNumber == 5) { GameObject.Instantiate(P65); }
                if (EpcNumber == 6) { GameObject.Instantiate(P66); }
                if (EpcNumber == 7) { GameObject.Instantiate(P67); }
                if (EpcNumber == 8) { GameObject.Instantiate(P68); }
            }
            
            if (MapNumber == 7)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P71); }
                if (EpcNumber == 2) { GameObject.Instantiate(P72); }
                if (EpcNumber == 3) { GameObject.Instantiate(P73); }
                if (EpcNumber == 4) { GameObject.Instantiate(P74); }
                if (EpcNumber == 5) { GameObject.Instantiate(P75); }
                if (EpcNumber == 6) { GameObject.Instantiate(P76); }
                if (EpcNumber == 7) { GameObject.Instantiate(P77); }
                if (EpcNumber == 8) { GameObject.Instantiate(P78); }
            }

            if (MapNumber == 8)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P81); }
                if (EpcNumber == 2) { GameObject.Instantiate(P82); }
                if (EpcNumber == 3) { GameObject.Instantiate(P83); }
                if (EpcNumber == 4) { GameObject.Instantiate(P84); }
                if (EpcNumber == 5) { GameObject.Instantiate(P85); }
                if (EpcNumber == 6) { GameObject.Instantiate(P86); }
                if (EpcNumber == 7) { GameObject.Instantiate(P87); }
                if (EpcNumber == 8) { GameObject.Instantiate(P88); }
            }

            if (MapNumber == 9)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P91); }
                if (EpcNumber == 2) { GameObject.Instantiate(P92); }
                if (EpcNumber == 3) { GameObject.Instantiate(P93); }
                if (EpcNumber == 4) { GameObject.Instantiate(P94); }
                if (EpcNumber == 5) { GameObject.Instantiate(P95); }
                if (EpcNumber == 6) { GameObject.Instantiate(P96); }
                if (EpcNumber == 7) { GameObject.Instantiate(P97); }
                if (EpcNumber == 8) { GameObject.Instantiate(P98); }
            }

            if (MapNumber == 10)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P101); }
                if (EpcNumber == 2) { GameObject.Instantiate(P102); }
                if (EpcNumber == 3) { GameObject.Instantiate(P103); }
                if (EpcNumber == 4) { GameObject.Instantiate(P104); }
                if (EpcNumber == 5) { GameObject.Instantiate(P105); }
                if (EpcNumber == 6) { GameObject.Instantiate(P106); }
                if (EpcNumber == 7) { GameObject.Instantiate(P107); }
                if (EpcNumber == 8) { GameObject.Instantiate(P108); }
            }

            if (MapNumber == 11)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P111); }
                if (EpcNumber == 2) { GameObject.Instantiate(P112); }
                if (EpcNumber == 3) { GameObject.Instantiate(P113); }
                if (EpcNumber == 4) { GameObject.Instantiate(P114); }
                if (EpcNumber == 5) { GameObject.Instantiate(P115); }
                if (EpcNumber == 6) { GameObject.Instantiate(P116); }
                if (EpcNumber == 7) { GameObject.Instantiate(P117); }
                if (EpcNumber == 8) { GameObject.Instantiate(P118); }
            }

            if (MapNumber == 12)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P121); }
                if (EpcNumber == 2) { GameObject.Instantiate(P122); }
                if (EpcNumber == 3) { GameObject.Instantiate(P123); }
                if (EpcNumber == 4) { GameObject.Instantiate(P124); }
                if (EpcNumber == 5) { GameObject.Instantiate(P125); }
                if (EpcNumber == 6) { GameObject.Instantiate(P126); }
                if (EpcNumber == 7) { GameObject.Instantiate(P127); }
                if (EpcNumber == 8) { GameObject.Instantiate(P128); }
            }

            if (MapNumber == 13)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P131); }
                if (EpcNumber == 2) { GameObject.Instantiate(P132); }
                if (EpcNumber == 3) { GameObject.Instantiate(P133); }
                if (EpcNumber == 4) { GameObject.Instantiate(P134); }
                if (EpcNumber == 5) { GameObject.Instantiate(P135); }
                if (EpcNumber == 6) { GameObject.Instantiate(P136); }
                if (EpcNumber == 7) { GameObject.Instantiate(P137); }
                if (EpcNumber == 8) { GameObject.Instantiate(P138); }
            }

            if (MapNumber == 14)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P141); }
                if (EpcNumber == 2) { GameObject.Instantiate(P142); }
                if (EpcNumber == 3) { GameObject.Instantiate(P143); }
                if (EpcNumber == 4) { GameObject.Instantiate(P144); }
                if (EpcNumber == 5) { GameObject.Instantiate(P145); }
                if (EpcNumber == 6) { GameObject.Instantiate(P146); }
                if (EpcNumber == 7) { GameObject.Instantiate(P147); }
                if (EpcNumber == 8) { GameObject.Instantiate(P148); }
            }

            if (MapNumber == 15)
            {
                if (EpcNumber == 1) { GameObject.Instantiate(P151); }
                if (EpcNumber == 2) { GameObject.Instantiate(P152); }
                if (EpcNumber == 3) { GameObject.Instantiate(P153); }
                if (EpcNumber == 4) { GameObject.Instantiate(P154); }
                if (EpcNumber == 5) { GameObject.Instantiate(P155); }
                if (EpcNumber == 6) { GameObject.Instantiate(P156); }
                if (EpcNumber == 7) { GameObject.Instantiate(P157); }
                if (EpcNumber == 8) { GameObject.Instantiate(P158); }
            }
            creating = false;
        }
    }
}
