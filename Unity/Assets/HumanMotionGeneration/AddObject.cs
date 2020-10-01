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
    GameObject StlObject = null;
    public void IportSTL(string path, Boolean isStatic)
    {
        StlObject = StlAssetPostProcessor.CreateStlParent(path);
        if (StlObject != null)
        {
            if (isStatic)
            {
                StlObject.isStatic = true;
            }
            StlObject.SetActive(false);
        }
    }

    void Update()
    {
        if ((StlObject != null) && !StlObject.activeSelf)
        {
            StlObject.SetActive(true);
        }
    }
}
