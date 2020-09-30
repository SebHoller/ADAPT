#region License
/*
* HumanMotionGeneration an expansion of Agent Development and Prototyping Testbed
* https://github.com/Sebauer98/ADAPT
* 
* Copyright (C) 2020 Sebastian Holler
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
using System;
using UnityEngine;
using System.Text.RegularExpressions;

public class Actions
{
    static readonly GameObject gameObject = new GameObject();
    readonly Behavior behavior = gameObject.AddComponent<Behavior>();
    readonly Transform trans = gameObject.AddComponent<Transform>();

    private string RemoveBrackets(string text)
    {
        try {
            return Regex.Replace(text, @"(,)", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
        }
        catch (RegexMatchTimeoutException) {
            return String.Empty;
        }
    }

    public void Wait(string param)
    {
        System.Threading.Thread.Sleep(Int32.Parse(param));
    }

    public void Walk(string param)
    {
        RemoveBrackets(param);
        string[] split = param.Split(',');
        Vector3 vec = new Vector3();
        switch (split.Length) {
            case 2:
                new Vector3(float.Parse(split[0]), float.Parse(split[1]));
                break;
            case 3:
                new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
                break;
            default:
                new Vector3();
                break;
        };
        behavior.Node_GoTo(vec);
    }

    public void LeftHand(string param)
    {
        behavior.Character.Body.Coordinator.reachArm = trans.Find("leftHand");
        RemoveBrackets(param);
        string[] split = param.Split(',');
        Vector3 vec = new Vector3();
        switch (split.Length) {
            case 2:
                new Vector3(float.Parse(split[0]), float.Parse(split[1]));
                break;
            case 3:
                new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
                break;
            default:
                new Vector3();
                break;
        };
        behavior.Node_Reach(vec);
    }

    public void RightHand(string param)
    {
        behavior.Character.Body.Coordinator.reachArm = trans.Find("rightHand");
        RemoveBrackets(param);
        string[] split = param.Split(',');
        Vector3 vec = new Vector3();
        switch (split.Length)
        {
            case 2:
                new Vector3(float.Parse(split[0]), float.Parse(split[1]));
                break;
            case 3:
                new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
                break;
            default:
                new Vector3();
                break;
        };
        behavior.Node_Reach(vec);
    }
}
