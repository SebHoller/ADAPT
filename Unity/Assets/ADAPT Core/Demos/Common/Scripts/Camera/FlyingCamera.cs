#region License
/*
* Agent Development and Prototyping Testbed
* https://github.com/ashoulson/ADAPT
* 
* Copyright (C) 2011-2015 Alexander Shoulson - ashoulson@gmail.com
* modified 2020 Sebastian Holler
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

using UnityEngine;
using System.Collections;

public class FlyingCamera : MonoBehaviour
{
    private float lookSpeed = 90.0f;
    private float moveSpeed = 15.0f;
    private float updownSpeed = 10.0f;

    private float rotationX = 180.0f;
    private float rotationY = -35.0f;

    // following lines copied from: https://gist.github.com/gunderson/d7f096bd07874f31671306318019d996
    private float mainSpeed = 0.5f; //regular speed
    private float shiftAdd = 1.5f; //multiplied by how long shift is held.  Basically running
    private float maxShift = 5.0f; //Maximum speed when holdin gshift
    private float totalRun = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -90, 90);
        }

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        float deltaMove = Time.deltaTime * this.moveSpeed;
        transform.position += transform.forward * Input.GetAxis("Vertical") * deltaMove;
        transform.position += transform.right * Input.GetAxis("Horizontal") * deltaMove;

        float deltaUpdown = Time.deltaTime * this.updownSpeed;
        if (Input.GetKey(KeyCode.Space))
            transform.position += Vector3.up * deltaUpdown;
        if (Input.GetKey(KeyCode.LeftControl))
            transform.position += Vector3.up * -deltaUpdown;

        // these lines copied from: https://gist.github.com/gunderson/d7f096bd07874f31671306318019d996
        Vector3 p = GetBaseInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            totalRun += Time.deltaTime;
            p = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }
        transform.Translate(p);
    }

    // these lines copied from: https://gist.github.com/gunderson/d7f096bd07874f31671306318019d996
    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
