using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLeanController : ShadowController
{
    public Transform spine;
    public override void ControlledStart()
    {
        this.spine = this.shadow.GetBone(this.spine);
    }
    public override void ControlledUpdate()
    {
        // Get the current euler angle rotation
        Vector3 rot = spine.rotation.eulerAngles;
        // Detect key input and add or subtract from the x rotation (scaling
        // by deltaTime to make this speed independent from the frame rate)
        if (Input.GetKey(KeyCode.R))
            rot.x -= Time.deltaTime * 50.0f;
        if (Input.GetKey(KeyCode.F))
            rot.x += Time.deltaTime * 50.0f;
        // Apply the new rotation
        spine.rotation = Quaternion.Euler(rot);
    }
}
