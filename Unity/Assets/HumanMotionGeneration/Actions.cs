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
using TreeSharpPlus;

public class Actions : MonoBehaviour
{
    Behavior behavior;
    Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        behavior = gameObject.AddComponent<Behavior>();
        trans = gameObject.AddComponent<Transform>();
    }

    // remove unnecessary brackets from coordinates
    private string RemoveBrackets(string text)
    {
        try {
            // replace brackets with empty string
            return Regex.Replace(text, @"(,),[,]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
        }
        catch (RegexMatchTimeoutException) {
            return String.Empty;
        }
    }

    // wait the given amount of milliseconds
    public Node Wait(string param)
    {
        return behavior.Node_Wait(param);
    }

    // walk to the desired coordinates
    public Node Walk(string param)
    {
        RemoveBrackets(param);
        string[] split = param.Split(',');
        Vector3 vec;
        // turn 2D coordinates into 3D coordinates
        // if coordinates are incompatible use (0,0,0)
        switch (split.Length) {
            case 2:
                vec = new Vector3(float.Parse(split[0]), float.Parse(split[1]));
                break;
            case 3:
                vec = new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
                break;
            default:
                vec = new Vector3(0,0,0);
                break;
        };
        return behavior.Node_GoTo(vec);
    }

    // move left hand to given coordinates
    public Node LeftHand(string param)
    {
        behavior.Character.Body.Coordinator.reachArm = trans.Find("LeftArm");
        RemoveBrackets(param);
        string[] split = param.Split(',');
        Vector3 vec;
        // turn 2D coordinates into 3D coordinates
        // if coordinates are incompatible use (0,0,0)
        switch (split.Length) {
            case 2:
                vec = new Vector3(float.Parse(split[0]), float.Parse(split[1]));
                break;
            case 3:
                vec = new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
                break;
            default:
                vec = new Vector3(0,0,0);
                break;
        };
        return behavior.Node_Reach(vec);
    }

    // move right hand to given coordinates
    public Node RightHand(string param)
    {
        behavior.Character.Body.Coordinator.reachArm = trans.Find("RightArm");
        RemoveBrackets(param);
        string[] split = param.Split(',');
        Vector3 vec;
        // turn 2D coordinates into 3D coordinates
        // if coordinates are incompatible use (0,0,0)
        switch (split.Length)
        {
            case 2:
                vec = new Vector3(float.Parse(split[0]), float.Parse(split[1]));
                break;
            case 3:
                vec = new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
                break;
            default:
                vec = new Vector3(0,0,0);
                break;
        };
        return behavior.Node_Reach(vec);
    }
}
