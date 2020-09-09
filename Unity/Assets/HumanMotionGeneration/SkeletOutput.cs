#region License
/*
* HumanMotionGeneration an expansion of Agent Development and Prototyping Testbed
* https://github.com/Sebauer98/ADAPT
* 
* Copyright (C) 2020 Sebastian Holler
*
* This file is part of ADAPT.
* 
* ADAPT is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published
* by the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
* 
* ADAPT is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
* 
* You should have received a copy of the GNU Lesser General Public License
* along with ADAPT.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using CsvHelper;
using System.Globalization;
using Numpy;
using System;

public class SkeletOutput : MonoBehaviour
{
    static StreamWriter writer;
    CsvWriter csv;
    // Start is called before the first frame update
    void Start()
    {
        writer = new StreamWriter("SkeletOutput.csv");
        csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    }

    // Update is called once per frame
    void Update()
    {
        if(File.Exists("SkeletOutput.csv"))
        {
            FileStream stream = File.Open("path\\to\\file.csv", FileMode.Append);
            writer = new StreamWriter(stream);
            csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.HasHeaderRecord = false;
        }
        Character character = gameObject.GetComponent<Character>();
        List<Output> list = new List<Output>
        {
            new Output
            {
                X = character.Body.Coordinator.hips.position.x,
                Y = character.Body.Coordinator.hips.position.y,
                Z = character.Body.Coordinator.hips.position.z,
                RightShoulderX = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("RightShoulder").transform.position.x,
                RightShoulderY = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("RightShoulder").transform.position.y,
                RightShoulderZ = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("RightShoulder").transform.position.z,
                LeftShoulderX = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("LeftShoulder").transform.position.x,
                LeftShoulderY = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("LightShoulder").transform.position.y,
                LeftShoulderZ = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("LeftShoulder").transform.position.z,
                HeadX = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("Neck").Find("Head").transform.position.x,
                HeadY = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("Neck").Find("Head").transform.position.y,
                HeadZ = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("Neck").Find("Head").transform.position.z,
                RightHandX = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("RightShoulder").Find("RightArm").Find("RightForeArm").Find("RightHand").transform.position.x,
                RightHandY = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("RightShoulder").Find("RightArm").Find("RightForeArm").Find("RightHand").transform.position.y,
                RightHandZ = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("RightShoulder").Find("RightArm").Find("RightForeArm").Find("RightHand").transform.position.z,
                LeftHandX = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").transform.position.x,
                LeftHandY = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").transform.position.y,
                LeftHandZ = character.Body.Coordinator.hips.Find("spine").Find("spine1").Find("spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").transform.position.z,
                RightFootX = character.Body.Coordinator.hips.Find("RightUpLeg").Find("RightLeg").Find("RightFoot").transform.position.x,
                RightFootY = character.Body.Coordinator.hips.Find("RightUpLeg").Find("RightLeg").Find("RightFoot").transform.position.y,
                RightFootZ = character.Body.Coordinator.hips.Find("RightUpLeg").Find("RightLeg").Find("RightFoot").transform.position.z,
                LeftFootX = character.Body.Coordinator.hips.Find("LeftUpLeg").Find("LeftLeg").Find("LeftFoot").transform.position.x,
                LeftFootY = character.Body.Coordinator.hips.Find("LeftUpLeg").Find("LeftLeg").Find("LeftFoot").transform.position.y,
                LeftFootZ = character.Body.Coordinator.hips.Find("LeftUpLeg").Find("LeftLeg").Find("LeftFoot").transform.position.z,
                Time = DateTime.Now
            }
        };
        csv.WriteRecords(list);
    }

    private class Output
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float RightShoulderX { get; set; }
        public float RightShoulderY { get; set; }
        public float RightShoulderZ { get; set; }
        public float LeftShoulderX { get; set; }
        public float LeftShoulderY { get; set; }
        public float LeftShoulderZ { get; set; }
        public float HeadX { get; set; }
        public float HeadY { get; set; }
        public float HeadZ { get; set; }
        public float RightHandX { get; set; }
        public float RightHandY { get; set; }
        public float RightHandZ { get; set; }
        public float LeftHandX { get; set; }
        public float LeftHandY { get; set; }
        public float LeftHandZ { get; set; }
        public float RightFootX { get; set; }
        public float RightFootY { get; set; }
        public float RightFootZ { get; set; }
        public float LeftFootX { get; set; }
        public float LeftFootY { get; set; }
        public float LeftFootZ { get; set; }
        public DateTime Time { get; set; }
    }
}
