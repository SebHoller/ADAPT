#region License
/*
* HumanMotionGeneration an expansion of Agent Development and Prototyping Testbed
* https://github.com/Sebauer98/ADAPT
* 
* Copyright (C) 2020 Sebastian Holler - seb.holler98@gmail.com
*
* This file is part of HumanMotionGeneration.
* This project extends ADAPT.
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
// using CsvHelper;
using System.Globalization;
using System;

public class SkeletOutput : MonoBehaviour
{
    // static StreamWriter writer;
    // CsvWriter csv;
    // Start is called before the first frame update
    void Start()
    {
        // writer = new StreamWriter("SkeletOutput.csv");
        // csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    }

    private void FixedUpdate()
    {
        /* if(File.Exists("SkeletOutput.csv"))
        {
            FileStream stream = File.Open("SkeletOutput.csv", FileMode.Append);
            writer = new StreamWriter(stream);
            // csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            // csv.Configuration.HasHeaderRecord = false;
        }*/
        Character character = gameObject.GetComponent<Character>();        
        Output output = new Output
        {
            // Time = DateTime.Now,
            Time = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
            X = character.Body.Coordinator.hips.position.x,
            Y = character.Body.Coordinator.hips.position.y,
            Z = character.Body.Coordinator.hips.position.z,
            RightShoulderX = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").transform.position.x,
            RightShoulderY = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").transform.position.y,
            RightShoulderZ = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").transform.position.z,
            LeftShoulderX = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").transform.position.x,
            LeftShoulderY = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").transform.position.y,
            LeftShoulderZ = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").transform.position.z,
            HeadX = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("Neck").Find("Head").transform.position.x,
            HeadY = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("Neck").Find("Head").transform.position.y,
            HeadZ = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("Neck").Find("Head").transform.position.z,
            RightHandX = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm").Find("RightForeArm").Find("RightHand").transform.position.x,
            RightHandY = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm").Find("RightForeArm").Find("RightHand").transform.position.y,
            RightHandZ = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm").Find("RightForeArm").Find("RightHand").transform.position.z,
            LeftHandX = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").transform.position.x,
            LeftHandY = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").transform.position.y,
            LeftHandZ = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").transform.position.z,
            RightFootX = character.Body.Coordinator.hips.Find("RightUpLeg").Find("RightLeg").Find("RightFoot").transform.position.x,
            RightFootY = character.Body.Coordinator.hips.Find("RightUpLeg").Find("RightLeg").Find("RightFoot").transform.position.y,
            RightFootZ = character.Body.Coordinator.hips.Find("RightUpLeg").Find("RightLeg").Find("RightFoot").transform.position.z,
            LeftFootX = character.Body.Coordinator.hips.Find("LeftUpLeg").Find("LeftLeg").Find("LeftFoot").transform.position.x,
            LeftFootY = character.Body.Coordinator.hips.Find("LeftUpLeg").Find("LeftLeg").Find("LeftFoot").transform.position.y,
            LeftFootZ = character.Body.Coordinator.hips.Find("LeftUpLeg").Find("LeftLeg").Find("LeftFoot").transform.position.z,
            LeftArmX = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").transform.position.x,
            LeftArmY = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").transform.position.y,
            LeftArmZ = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").transform.position.z,
            LeftLegX = character.Body.Coordinator.hips.Find("LeftUpLeg").Find("LeftLeg").transform.position.x,
            LeftLegY = character.Body.Coordinator.hips.Find("LeftUpLeg").Find("LeftLeg").transform.position.y,
            LeftLegZ = character.Body.Coordinator.hips.Find("LeftUpLeg").Find("LeftLeg").transform.position.z,
            RightArmX = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm").transform.position.x,
            RightArmY = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm").transform.position.y,
            RightArmZ = character.Body.Coordinator.hips.Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm").transform.position.z,
            RightLegX = character.Body.Coordinator.hips.Find("RightUpLeg").Find("RightLeg").transform.position.x,
            RightLegY = character.Body.Coordinator.hips.Find("RightUpLeg").Find("RightLeg").transform.position.y,
            RightLegZ = character.Body.Coordinator.hips.Find("RightUpLeg").Find("RightLeg").transform.position.z
        };

        string text = "Time: " + output.Time + "; position: (" + output.X + "| " + output.Y + "| " + output.Z + "); right Shoulder: (" + output.RightShoulderX + "| " + output.RightShoulderY + "| " + output.RightShoulderZ + "); left Shoulder: (" + output.LeftShoulderX + "| " + output.LeftShoulderY + "| " + output.LeftShoulderZ + "); right Arm: (" + output.RightArmX + "| " + output.RightArmY + "| " + output.RightArmZ + "); left Arm: (" + output.LeftArmX + "| " + output.LeftArmY + "| " + output.LeftArmZ + "); right Hand: (" + output.RightHandX + "| " + output.RightHandY + "| " + output.RightHandZ + "); left Hand: (" + output.LeftHandX + "| " + output.LeftHandY + "| " + output.LeftHandZ + "); Head: (" + output.HeadX + "| " + output.HeadY + "| " + output.HeadZ + "); right Leg: (" + output.RightLegX + "| " + output.RightLegY + "| " + output.RightLegZ + "); left Leg:(" + output.LeftLegX + "| " + output.LeftLegY + "| " + output.LeftLegZ + "); right Foot:(" + output.RightFootX + "| " + output.RightFootY + "| " + output.RightFootZ + "); left Foot:( " + output.LeftFootX + "| " + output.LeftFootY + "| " + output.LeftFootZ + ");";
        using (StreamWriter file =
            new StreamWriter(@"C:\projects\ADAPT\Unity\Assets\HumanMotionGeneration\SkeletOutput.txt", true))
        {
            file.WriteLine(text);
        }
        // csv.WriteRecords(list);
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
        public float LeftArmX { get; set; }
        public float LeftArmY { get; set; }
        public float LeftArmZ { get; set; }
        public float LeftLegX { get; set; }
        public float LeftLegY { get; set; }
        public float LeftLegZ { get; set; }
        public float RightArmX { get; set; }
        public float RightArmY { get; set; }
        public float RightArmZ { get; set; }
        public float RightLegX { get; set; }
        public float RightLegY { get; set; }
        public float RightLegZ { get; set; }
        //public DateTime Time { get; set; }
        public string Time { get; set; }
    }
}
