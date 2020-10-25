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
using TreeSharpPlus;
using System.Globalization;

public class Actions : MonoBehaviour
{
    Behavior behavior;

    // Start is called before the first frame update
    void Start()
    {
        behavior = gameObject.AddComponent<Behavior>();
    }

    // remove unnecessary brackets from coordinates
    private string RemoveBrackets(string text)
    {
        return text.Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "");
    }

    // walk to the desired coordinates
    public Node Walk(string param)
    {
        param = RemoveBrackets(param);
        string[] split = param.Split(',');
        Vector3 vec;
        float x;
        float y;
        float z;
        // turn 2D coordinates into 3D coordinates
        // if coordinates are incompatible use (0,0,0)
        switch (split.Length) {
            case 2:
                float.TryParse(split[0], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out x);
                float.TryParse(split[1], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out y);
                vec = new Vector3(x, y);
                break;
            case 3:
                float.TryParse(split[0], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out x);
                float.TryParse(split[1], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out y);
                float.TryParse(split[2], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out z);
                vec = new Vector3(x, y, z);
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
        param = RemoveBrackets(param);
        string[] split = param.Split(',');
        Vector3 vec;
        float x;
        float y;
        float z;
        // turn 2D coordinates into 3D coordinates
        // if coordinates are incompatible use (0,0,0)
        switch (split.Length) {
            case 2:
                float.TryParse(split[0], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out x);
                float.TryParse(split[1], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out y);
                vec = new Vector3(x, y);
                break;
            case 3:
                float.TryParse(split[0], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out x);
                float.TryParse(split[1], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out y);
                float.TryParse(split[2], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out z);
                vec = new Vector3(x, y, z);
                break;
            default:
                vec = new Vector3(0,0,0);
                break;
        };
        return behavior.Node_Reach(vec, true);
    }

    // move right hand to given coordinates
    public Node RightHand(string param)
    {
        param = RemoveBrackets(param);
        string[] split = param.Split(',');
        Vector3 vec;
        float x;
        float y;
        float z;
        // turn 2D coordinates into 3D coordinates
        // if coordinates are incompatible use (0,0,0)
        switch (split.Length)
        {
            case 2:
                float.TryParse(split[0], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out x);
                float.TryParse(split[1], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out y);
                vec = new Vector3(x, y);
                break;
            case 3:
                float.TryParse(split[0], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out x);
                float.TryParse(split[1], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out y);
                float.TryParse(split[2], NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, result: out z);
                vec = new Vector3(x, y, z);
                break;
            default:
                vec = new Vector3(0,0,0);
                break;
        };
        return behavior.Node_Reach(vec, false);
    }
}
