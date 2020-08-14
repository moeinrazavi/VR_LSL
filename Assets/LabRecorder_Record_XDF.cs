using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class LabRecorder_Record_XDF : MonoBehaviour
{
    // Start is called before the first frame update
    public string Save_Path = @"C:\Users\" + Environment.UserName + @"\Desktop\Unity_Data\";
    void Start()
    {
        string strCmdText;
        string curr_day = System.DateTime.Now.Day.ToString();
        string curr_mon = System.DateTime.Now.Month.ToString();
        string curr_year = System.DateTime.Now.Year.ToString();
        string curr_hour = System.DateTime.Now.Hour.ToString();
        string curr_min = System.DateTime.Now.Minute.ToString();
        string curr_sec = System.DateTime.Now.Second.ToString();
        string curr_time = curr_mon + "-" + curr_day + "-" + curr_year + "_" + curr_hour + "-" + curr_min + "-" + curr_sec;
        
        if (!Directory.Exists(Save_Path)) Directory.CreateDirectory(Save_Path);
        strCmdText = @"/C .\Assets\LabRecorder\LabRecorderCLI.exe " + Save_Path + curr_time + ".xdf 'searchstr'";
        System.Diagnostics.Process.Start("CMD.exe", strCmdText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
