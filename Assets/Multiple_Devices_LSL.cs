using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiple_Devices_LSL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        //###################################
        //############# EEG LSL #############
        //###################################
        //""" Run Unicorn LSL -- Sending Unicorn Data to LSL """
        System.Diagnostics.Process.Start("CMD.exe", @"/C .\Assets\UnicornLSL\UnicornLSL.exe");
        //""" Run BrainProducts LiveAmp - 16 Channel LSL -- Send LiveAmp Data to LSL """
        System.Diagnostics.Process.Start("CMD.exe", @"/C .\Assets\LiveAmp16-LSL\LiveAmp-LSL.exe");
        //""" Run OpenBCI Send Data to LSL """
        System.Diagnostics.Process.Start("CMD.exe", @"/C python .\Assets\OpenBCILSL\OpenBCILSL.py");
        //""" Send Mindwave data to LSL -- 
        //Remember to install Mindwave LSL using: pip install mindwavelsl """
        System.Diagnostics.Process.Start("CMD.exe", @"/C python .\Assets\MindwaveLSL\mindwave_LSL.py");
        //""" Send Muse data to LSL """
        //""" Download and Install Bluemuse from:
        //    https://github.com/kowalej/BlueMuse/releases/download/v2.1/BlueMuse_2.1.0.0.zip
        //        1.Navigate to the unzipped app folder and run the .\InstallBlueMuse.ps1 PowerShell
        //            command(right click and choose Run with PowerShell or execute from terminal directly):
        //        2.Follow the prompts -the script should automatically
        //          install the security certificate, all dependencies, and the BlueMuse app.
        //    Reference: https://github.com/kowalej/BlueMuse """
        //# Set LSL_LOCAL_CLOCK for MUSE and Send Muse Data to LSL
        System.Diagnostics.Process.Start("CMD.exe", "/C start bluemuse://setting?key=primary_timestamp_format!value=LSL_LOCAL_CLOCK_NATIVE");
        System.Diagnostics.Process.Start("CMD.exe", "/C start bluemuse://start?streamfirst=true");

        //###################################
        //############# GSR LSL #############
        //###################################
        //""" Run GSR Send to LSL """
        System.Diagnostics.Process.Start("CMD.exe", @"/C python .\Assets\GSR_eHealth\Serial2LSL.py");

        //##################################################
        //############# KINECT BODY BASICS LSL #############
        //##################################################
        //""" Run Kinect Body Basics LSL -- Sending kinect Body Basics Data to LSL """
        //""" Remember to Download and Install Microsoft Kinect for Windows SDK 2.0 from:
        //    https://www.microsoft.com/en-us/download/details.aspx?id=44561
        //        Restart your PC after installing Kinect SDK """
        System.Diagnostics.Process.Start("CMD.exe", @"/C .\Assets\Kinect-BodyBasics-LSL\BodyBasicsLSL.exe");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
