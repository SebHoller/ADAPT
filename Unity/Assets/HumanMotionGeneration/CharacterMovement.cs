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
    Actions actions;
    Behavior behavior;
    List<Node> nodes;
    bool running;

    // Start is called before the first frame update
    void Start()
    {
        actions = gameObject.AddComponent<Actions>();
        nodes = null;
        running = false;
    }

    // import a text file with commands for the character
    public void InputCharacterMovements(string path)
    {
        // read the text file
        string[] lines = System.IO.File.ReadAllLines(path);
        behavior = gameObject.AddComponent<Behavior>();
        running = false;
        nodes = new List<Node>();

        // for every line of the text file do the following
        foreach (string line in lines)
        {
            string[] split = line.Split(':');
            string action = split[0];
            string param = split[1];
            // switch the commands and add the requested one
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

    // creates the sequence for the behaviour tree
    private Node MovementTree()
    {
        return new Sequence(nodes.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        // check whether the animations are running
        if ((nodes != null) && (!running))
        {
            // start the animation of the commands
            running = true;
            BehaviorEvent.Run(this.MovementTree(), this.behavior);
        }
    }
}
