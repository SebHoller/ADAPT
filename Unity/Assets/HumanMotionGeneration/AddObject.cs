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

public class AddObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Console.WriteLine("Please enter the path to your stl-file");
        string path = Console.ReadLine();
        GameObject StlObject = StlAssetPostProcessor.CreateStlParent(path);
        if (StlObject != null)
        {
            Console.WriteLine("Please enter if this object is fixed (true/false/Y/N");
            string fixed_in = Console.ReadLine();
            bool fix;
            switch (fixed_in)
            {
                case "true":
                case "Y":
                    fix = true;
                    break;
                case "false":
                case "N":
                    fix = false;
                    break;
                default:
                    fix = true;
                    break;
            }
            if (fix)
            {
                StlObject.isStatic = true;
            }
            StlObject.SetActive(true);
        }
    }
}
