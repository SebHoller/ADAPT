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
using System;
using UnityEngine;

public class Actions
{
    static readonly GameObject gameObject = new GameObject();
    readonly Behavior behavior = gameObject.AddComponent<Behavior>();
    readonly Transform trans = gameObject.AddComponent<Transform>();
    public void Wait(string time)
    {
        System.Threading.Thread.Sleep(Int32.Parse(time));
    }

    public void Walk(string param)
    {
        string[] split = param.Split(',');
        var vec = split.Length switch
        {
            2 => new Vector3(float.Parse(split[0]), float.Parse(split[1])),
            3 => new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2])),
            _ => new Vector3(),
        };
        behavior.Node_GoTo(vec);
    }

    public void LeftHand(string param)
    {
        behavior.Character.Body.Coordinator.reachArm = trans.Find("leftHand");
        string[] split = param.Split(',');
        var vec = split.Length switch
        {
            2 => new Vector3(float.Parse(split[0]), float.Parse(split[1])),
            3 => new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2])),
            _ => new Vector3(),
        };
        behavior.Node_Reach(vec);
    }

    public void RightHand(string param)
    {
        behavior.Character.Body.Coordinator.reachArm = trans.Find("rightHand");
        string[] split = param.Split(',');
        var vec = split.Length switch
        {
            2 => new Vector3(float.Parse(split[0]), float.Parse(split[1])),
            3 => new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2])),
            _ => new Vector3(),
        };
        behavior.Node_Reach(vec);
    }
}
