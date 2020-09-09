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

public class CharacterMovement : MonoBehaviour
{
    string[] instructions;
    string[] parameter;
    int counter = 0;
    readonly Actions actions = new Actions();

    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("Please enter the path to the text file with actions:");
        string path = Console.ReadLine();
        string[] lines = ReadFile.ReadLines(path);
        instructions = new string[lines.Length];
        parameter = new string[lines.Length];
        for(int i=0; i<lines.Length; i++)
        {
            string line = lines[i];
            string[] split = line.Split(':');
            instructions[i] = split[0];
            parameter[i] = split[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        string instruction = instructions[counter];
        string param = parameter[counter];
        switch (instruction)
        {
            case "wait":
                actions.Wait(param);
                break;
            case "walk":
                actions.Walk(param);
                break;
            case "leftHand":
                actions.LeftHand(param);
                break;
            case "rightHand":
                actions.RightHand(param);
                break;
            default:
                break;
        }
        counter++;
    }
}
