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

public class STLImport : MonoBehaviour
{
    // the created gameobject will be stored in this attribute
    GameObject StlObject = null;
    // the desired location will be stored here
    Vector3 vec;
    // the rotation of the object will be stored here
    Quaternion quaternion;

    /// <summary>
    /// interface for importing the STL
    /// creates a GameObject and sets its parameters
    /// </summary>
    /// <param name="path">the path of the STL-file</param>
    /// <param name="coordinates">the desired coordinates for the GameObject</param>
    /// <param name="isStatic">static or moveable GameObject</param>
    /// <param name="quaternion">the rotation for the GameObject</param>
    public void ImportSTL(string path, Vector3 coordinates, bool isStatic, Quaternion quaternion)
    {
        // creates a gameObject out of an STL-file
        StlObject = StlAssetPostProcessor.CreateStlParent(path);
        // check if it is actually created
        if (StlObject != null)
        {
            // set it static or movable depending on the input
            StlObject.isStatic = isStatic;
            // do not yet set it active
            StlObject.SetActive(false);
        }
        // the coordinates for the object
        vec = coordinates;
        // the rotation of the object
        this.quaternion = quaternion;
    }

    // Update is called once per frame
    void Update()
    {
        // chack if the object is created and not yet activated
        if ((StlObject != null) && !StlObject.activeSelf)
        {
            // activate the gameObject
            StlObject.SetActive(true);
            // load it into the scene at the provided coordinates with no rotation
            Instantiate(StlObject, vec, quaternion);
        }
    }
}
