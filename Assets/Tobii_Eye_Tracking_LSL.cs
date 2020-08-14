using UnityEngine;
using System.Collections;
using LSL;
using System.Diagnostics;
using Tobii.XR;

namespace Assets.LSL4Unity.Scripts
{
    public class Tobii_Eye_Tracking_LSL : MonoBehaviour
    {
        private liblsl.StreamOutlet outlet;
        private liblsl.StreamInfo streamInfo;
        private float[] currentSample;

        public string StreamName = "Tobii_Eyetracking";
        public string StreamType = "Eyetracking";
        private int ChannelCount = 3;

        private TobiiXR_Settings Settings;

        private void Awake()
        {
            TobiiXR.Start(Settings);
        }
        // Use this for initialization
        // Use this for initialization
        void Start()
        {

            currentSample = new float[ChannelCount];

            streamInfo = new liblsl.StreamInfo(StreamName, StreamType, ChannelCount);

            outlet = new liblsl.StreamOutlet(streamInfo);
        }

        public void FixedUpdate()
        {
            // Get eye tracking data in world space
            var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);

            // Check if gaze ray is valid
            if (eyeTrackingData.GazeRay.IsValid)
            {
                // The origin of the gaze ray is a 3D point
                var rayOrigin = eyeTrackingData.GazeRay.Origin;

                // The direction of the gaze ray is a normalized direction vector
                var rayDirection = eyeTrackingData.GazeRay.Direction;

                currentSample[0] = rayDirection.x;
                currentSample[1] = rayDirection.y;
                currentSample[2] = rayDirection.z;
                outlet.push_sample(currentSample);
            }


        }
    }
}