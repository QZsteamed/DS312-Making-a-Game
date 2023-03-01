using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class VR_Tag
{
    public string EpcName { get; set; }
    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string BundleUrl { get; set; }

    public string AssetName { get; set; }

    public VR_Tag()
    {

    }

    public VR_Tag ParsedFromJSON(string json)
    {
        //Debug.Log("json data:" + json);
        if (json.Contains("EpcName"))
            return JsonConvert.DeserializeObject<VR_Tag>(json);
        else
            return this;
    }

    public static List<VR_Tag> ExtractFromCsvFile()
    {
        List<VR_Tag> tags = new List<VR_Tag>();

        string[] rows = File.ReadAllLines("sample.csv");

        for (int i = 1; i < rows.Length; i++)
        {
            string[] items = rows[i].Split(',');

            VR_Tag vR_Tag = new VR_Tag();
            if (items[0] == null || items[0] == "") break;
            vR_Tag.EpcName = items[0];

            if (items[1] == null || items[1] == "") vR_Tag.Latitude = null;
            else
            {
                vR_Tag.Latitude = Convert.ToDouble(items[1].Replace('.', ','));
            }


            if (items[2] == null || items[2] == "") vR_Tag.Longitude = null;
            else
            {
                vR_Tag.Longitude = Convert.ToDouble(items[2].Replace('.', ','));
            }

            vR_Tag.BundleUrl = items[3];
            vR_Tag.AssetName = items[4];

            tags.Add(vR_Tag);
        }

        return tags;

    }


}
