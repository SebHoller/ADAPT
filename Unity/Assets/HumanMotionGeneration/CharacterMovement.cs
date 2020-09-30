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
    Queue<string> instructions = null;
    Queue<string> parameter = null;
    readonly Actions actions = new Actions();
    Behavior behavior;
    Queue<Node> nodes = null;
    Boolean running = false;

    public void Initialize(string path)
    {
        string[] lines = System.IO.File.ReadAllLines(path);
        instructions = new Queue<string>();
        parameter = new Queue<string>();
        behavior = new Behavior();
        running = false;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] split = line.Split(':');
            instructions.Enqueue(split[0]);
            parameter.Enqueue(split[1]);
        }

        nodes = new Queue<Node>();
        while (instructions.Count>0)
        {
            string instruction = instructions.Dequeue();
            string param = parameter.Dequeue();
            switch (instruction)
            {
                case "wait":
                    nodes.Enqueue(actions.Wait(param));
                    break;
                case "walk":
                    nodes.Enqueue(actions.Walk(param));
                    break;
                case "leftHand":
                    nodes.Enqueue(actions.LeftHand(param));
                    break;
                case "rightHand":
                    nodes.Enqueue(actions.RightHand(param));
                    break;
                default:
                    Console.Error.WriteLine("The command \"" + instruction + "\" is not implemented.");
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
