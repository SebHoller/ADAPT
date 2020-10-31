#region License
/*
* Agent Development and Prototyping Testbed
* https://github.com/ashoulson/ADAPT
* 
* Copyright (C) 2011-2015 Alexander Shoulson - ashoulson@gmail.com
* modified (C) 2020 Sebastian Holler - seb.holler98@gmail.com
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
using TreeSharpPlus;
using System;

public class Character : MonoBehaviour, ICharacter
{
    private readonly float dist = 0.5f;
    private DateTime start;
    private bool started = false;
    private bool stopped = false;
    private bool setArm = false;
    private Val<Vector3> lastTarget = null;

    /// <summary>
    /// The Body interface for this character. Sits below this level in the
    /// ADAPT character stack.
    /// </summary>
    [HideInInspector]
    public Body Body;

    void Awake() { this.Initialize(); }

    /// <summary>
    /// Searches for and binds a reference to the Body interface
    /// </summary>
    public void Initialize() 
    {
        this.Body = this.GetComponent<Body>(); 
    }

    /// <summary>
    /// What gesture we're currently running, if any
    /// </summary>
    private string currentGesture = null;

    /// <summary>
    /// Sets a new navigation target. Will fail immediately if the
    /// point is unreachable. Blocks until the agent arrives.
    /// </summary>
    public virtual RunStatus NavGoTo(Val<Vector3> target)
    {
        if (this.Body.NavCanReach(target.Value) == false)
            return RunStatus.Failure;
        // TODO: I previously had this if statement here to prevent spam:
        //     if (this.Interface.NavTarget() != target)
        // It's good for limiting the amount of SetDestination() calls we
        // make internally, but sometimes it causes the character to stand
        // still when we re-activate a tree after it's been terminated. Look
        // into a better way to make this smarter without false positives. - AS
        this.Body.NavGoTo(target.Value);
        if (this.Body.NavHasArrived() == true)
            return RunStatus.Success;
        return RunStatus.Running;
        // TODO: Timeout? - AS
    }

    /// <summary>
    /// Stops the Navigation system. Blocks until the agent is stopped.
    /// </summary>
    public virtual RunStatus NavStop()
    {
        this.Body.NavStop();
        if (this.Body.NavIsStopped() == true)
            return RunStatus.Success;
        return RunStatus.Running;
        // TODO: Timeout? - AS
    }

    /// <summary>
    /// Turns to face a desired target point
    /// </summary>
    public virtual RunStatus NavTurn(Val<Vector3> target)
    {
        this.Body.NavSetOrientationBehavior(OrientationBehavior.None);
        this.Body.NavSetDesiredOrientation(target.Value);
        if (this.Body.NavIsFacingDesired() == true)
        {
            this.Body.NavSetOrientationBehavior(
                OrientationBehavior.LookForward);
            return RunStatus.Success;
        }
        return RunStatus.Running;
    }

    /// <summary>
    /// Turns to face a desired orientation
    /// </summary>
    public virtual RunStatus NavTurn(Val<Quaternion> target)
    {
        this.Body.NavSetOrientationBehavior(OrientationBehavior.None);
        this.Body.NavSetDesiredOrientation(target.Value);
        if (this.Body.NavIsFacingDesired() == true)
        {
            this.Body.NavSetOrientationBehavior(
                OrientationBehavior.LookForward);
            return RunStatus.Success;
        }
        return RunStatus.Running;
    }

    /// <summary>
    /// Sets a custom orientation behavior
    /// </summary>
    public virtual RunStatus NavOrientBehavior(
        Val<OrientationBehavior> behavior)
    {
        this.Body.NavSetOrientationBehavior(behavior.Value);
        return RunStatus.Success;
    }

    /// <summary>
    /// Stops the Reach controller. Blocks until it successfully reaches.
    /// </summary>
    public virtual RunStatus ReachFor(Val<Vector3> target)
    {
        if (!started && ((lastTarget == null) || (lastTarget.Value != target.Value)))
        {
            lastTarget = target;
            started = true;
            start = DateTime.Now;
            stopped = false;
        }
        if(!stopped)
        {
            // TODO: Heuristic check here - AS
            this.Body.ReachFor(target.Value);
        }
        // TODO: Currently, this blocks indefinitely. - AS
        // if (this.Body.ReachHasReached() == true)
        //     return RunStatus.Success;
        if (ReachHasReached(target, true))
        {
            started = false;
            stopped = true;
            return ReachStop();
        }
        return RunStatus.Running;
        // TODO: Timeout? - AS
    }

    private bool ReachHasReached(Val<Vector3> target, bool left)
    {
        if (DateTime.Compare(DateTime.Now, start.AddSeconds(10)) >= 0)
        {
            return true;
        }

        // bool x = Math.Abs(this.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").position.x - target.Value.x) <= dist;
        // bool y = Math.Abs(this.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").position.y - target.Value.y) <= dist;
        // bool z = Math.Abs(this.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").position.z - target.Value.z) <= dist;

        // bool x = Math.Abs(target.Value.x - this.Body.Coordinator.reachArm.position.x) <= dist;
        // bool y = Math.Abs(target.Value.y - this.Body.Coordinator.reachArm.position.y) <= dist;
        // bool z = Math.Abs(target.Value.z - this.Body.Coordinator.reachArm.position.z) <= dist;

        // bool x = Math.Abs(target.Value.x - this.Body.Coordinator.reach.endEffector.position.x) <= dist;
        // bool y = Math.Abs(target.Value.y - this.Body.Coordinator.reach.endEffector.position.y) <= dist;
        // bool z = Math.Abs(target.Value.z - this.Body.Coordinator.reach.endEffector.position.z) <= dist;

        // return (x && y && z);

        // return this.Body.Coordinator.reach.HasReached;
        if (left)
        {
            return (target.Value - this.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").position).sqrMagnitude <= dist;
        } else
        {
            return (target.Value - this.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm").Find("RightForeArm").Find("RightHand").position).sqrMagnitude <= dist;
        }
    }

    /// <summary>
    /// Stops the Reach controller. Blocks until it successfully reaches.
    /// </summary>
    public virtual RunStatus ReachFor(Val<Vector3> target, bool left)
    {
        if (!started && ((lastTarget == null) || (lastTarget.Value != target.Value)))
        {
            lastTarget = target;
            started = true;
            start = DateTime.Now;
            stopped = false;
        }
        
        if (!stopped)
        {
            if(!setArm)
            {
                if (left)
                {
                    IKJoint[] bones = new IKJoint[3];
                    bones[0] = new IKJoint(this.Body.Coordinator.reach.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm"));
                    bones[1] = new IKJoint(this.Body.Coordinator.reach.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm"));
                    bones[2] = new IKJoint(this.Body.Coordinator.reach.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand"));
                    Body.Coordinator.reach.bones = bones;
                    Body.Coordinator.reach.endEffector = this.Body.Coordinator.reach.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm").Find("LeftForeArm").Find("LeftHand").Find("LeftHandIndex1");
                    Body.Coordinator.reachArm = this.Body.Coordinator.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("LeftShoulder").Find("LeftArm");
                }
                else
                {
                    IKJoint[] bones = new IKJoint[3];
                    bones[0] = new IKJoint(this.Body.Coordinator.reach.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm"));
                    bones[1] = new IKJoint(this.Body.Coordinator.reach.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm").Find("RightForeArm"));
                    bones[2] = new IKJoint(this.Body.Coordinator.reach.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm").Find("RightForeArm").Find("RightHand"));
                    Body.Coordinator.reach.bones = bones;
                    Body.Coordinator.reach.endEffector = this.Body.Coordinator.reach.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm").Find("RightForeArm").Find("RightHand").Find("RightHandIndex1");
                    Body.Coordinator.reachArm = this.Body.Coordinator.transform.Find("Hips").Find("Spine").Find("Spine1").Find("Spine2").Find("RightShoulder").Find("RightArm");
                }
                setArm = true;
            }

            // TODO: Heuristic check here - AS
            this.Body.ReachFor(target.Value);
        }
        // TODO: Currently, this blocks indefinitely. - AS
        // if (this.Body.ReachHasReached() == true)
        //     return RunStatus.Success;
        if (ReachHasReached(target, left))
        {
            started = false;
            stopped = true;
            setArm = false;
            return ReachStop();
            // return RunStatus.Success;
        }
        return RunStatus.Running;
        // TODO: Timeout? - AS
    }

    /// <summary>
    /// Stops the Reach controller. Blocks until it's fully faded out.
    /// </summary>
    public virtual RunStatus ReachStop()
    {
        this.Body.ReachStop();
        if (this.Body.Coordinator.rWeight.IsMin == true)
            return RunStatus.Success;
        return RunStatus.Running;
        // TODO: Timeout? - AS
    }

    /// <summary>
    /// Starts the HeadLook controller. Blocks until it's fully faded in.
    /// </summary>
    public virtual RunStatus HeadLook(Val<Vector3> target)
    {
        this.Body.HeadLookAt(target.Value);
        // TODO: Maybe actually check the alignment here? - AS
        // TODO: Currently, this blocks indefinitely. - AS
        //if (this.Body.Coordinator.hWeight.IsMax == true)
        //    return RunStatus.Success;
        return RunStatus.Running;
        // TODO: Timeout? - AS
    }

    /// <summary>
    /// Stops the HeadLook controller. Blocks until it's fully faded out.
    /// </summary>
    public virtual RunStatus HeadLookStop()
    {
        this.Body.HeadLookStop();
        // TODO: Maybe actually check the alignment here? - AS
        if (this.Body.Coordinator.hWeight.IsMin == true)
            return RunStatus.Success;
        return RunStatus.Running;
        // TODO: Timeout? - AS
    }

    /// <summary>
    /// Plays a gesture animation and blocks until it's done. Will fail if
    /// told to play a second animation while one is already active.
    /// </summary>
    public virtual RunStatus Gesture(Val<string> name)
    {
        // Cache the name's value
        string nameVal = name.Value;

        // We're not (visibly) playing an animation
        if (this.Body.Coordinator.aWeight.IsMinPrecise == true)
        {
            // Did we just finish playing the requested one?
            if (this.currentGesture == nameVal)
            {
                this.currentGesture = null;
                return RunStatus.Success;
            }
            // If not, start the animation
            else
            {
                this.currentGesture = nameVal;
                this.Body.AnimPlay(nameVal);
                return RunStatus.Running;
            }
        }
        // We're playing an animation, or transitioning
        else
        {
            if (this.currentGesture == nameVal)
            {
                return RunStatus.Running;
            }
            else
            {
                // We're busy with another animation
                return RunStatus.Failure;
            }
        }
    }

    /// <summary>
    /// Stops all gesture animation and blocks until they're done.
    /// </summary>
    public virtual RunStatus GestureStop()
    {
        this.Body.AnimStop();

        // We're not (visibly) playing an animation
        if (this.Body.Coordinator.aWeight.IsMinPrecise == true)
        {
            // Fully terminate the animation
            this.Body.AnimStopImmediate();
            this.currentGesture = null;
            return RunStatus.Success;
        }

        // TODO: Timeout? - AS
        return RunStatus.Running;
    }
}
