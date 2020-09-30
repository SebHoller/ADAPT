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
using System.Collections.Generic;
using TreeSharpPlus;

public class CharacterMovement : MonoBehaviour
{
    readonly Actions actions = new Actions();
    Behavior behavior;
    List<Node> nodes = null;
    Boolean running = false;

    public void InputCharacterMovements(string path)
    {
        string[] lines = System.IO.File.ReadAllLines(path);
        behavior = gameObject.AddComponent<Behavior>();
        running = false;
        nodes = new List<Node>();

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] split = line.Split(':');
            string action = split[0];
            string param = split[1];
            switch (action)
            {
                case "wait":
                    nodes.Add(actions.Wait(param));
                    break;
                case "walk":
                    nodes.Add(actions.Walk(param));
                    break;
                case "leftHand":
                    nodes.Add(actions.LeftHand(param));
                    break;
                case "rightHand":
                    nodes.Add(actions.RightHand(param));
                    break;
                default:
                    Console.Error.WriteLine("The command \"" + action + "\" is not implemented.");
                    break;
            }
        }
    }

    private Node MovementTree()
    {
        return new Sequence(nodes.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        if ((nodes != null) && (!running))
        {
            running = true;
            BehaviorEvent.Run(this.MovementTree(), this.behavior);
        }
    }
}
