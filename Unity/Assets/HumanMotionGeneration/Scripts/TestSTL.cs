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
using UnityEngine;

public class TestSTL : MonoBehaviour
{
    STLImport stlImport;
    // Start is called before the first frame update
    void Start()
    {
        this.stlImport = gameObject.GetComponent<STLImport>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) == true)
        {
            string path = "Assets\\HumanMotionGeneration\\STL\\10260_Workbench_max8_v1_iterations-2.stl";
            this.stlImport.ImportSTL(path, true, new Vector3(5, 5, 1), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.K) == true)
        {
            string path = "Assets\\HumanMotionGeneration\\STL\\13604_Drill_Press_v1_L2.stl";
            this.stlImport.ImportSTL(path, true, new Vector3(-5, -10, 0), Quaternion.identity);
        }
    }
}
