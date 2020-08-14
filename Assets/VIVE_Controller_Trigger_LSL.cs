using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

using Assets.LSL4Unity.Scripts; // reference the namespace to get access to all classes



public class VIVE_Controller_Trigger_LSL : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean Trigger_Data;
    // a reference to the hand
    public SteamVR_Input_Sources handType;

    private LSLMarkerStream Trigger_Marker;
    private bool Trigger_Last_State = false;  // When the trigger is pressed, Trigger_Last_State is "true" otherwise "false"

    void Start()
    {
        Trigger_Data.AddOnStateDownListener(TriggerDown, handType);
        Trigger_Data.AddOnStateUpListener(TriggerUp, handType);

        Trigger_Marker = FindObjectOfType<LSLMarkerStream>();
    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (Trigger_Last_State == true)
        {
            Trigger_Last_State = false;
            Trigger_Marker.Write("Trigger Released");
        }
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (Trigger_Last_State == false)
        {
            Trigger_Last_State = true;
            Trigger_Marker.Write("Trigger Pressed");
        }
    }

    void Update()
    {
    }
}