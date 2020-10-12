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

public class LoopMovement : Behavior
{
    protected Node SubTree(Val<Vector3> position)
    {
        return new Sequence(
            this.Node_GoTo(position),
            new LeafWait(4000));
    }

    protected Node Tree()
    {
        Vector3 one = new Vector3((float)15.52169, (float)18.3128, (float)-2.37279);
        Vector3 two = new Vector3((float)7.352128, (float)20.19779, (float)-24.83835);
        Vector3 three = new Vector3((float)-16.81005, (float)18.13869, (float)6.542959);
        Vector3 four = new Vector3((float)-0.1038542, (float)17.95741, (float)-7.363914);
        Vector3 five = new Vector3((float)19.74192, (float)17.95741, (float)-11.77148);
        return
            new DecoratorLoop(
                new DecoratorForceStatus(RunStatus.Success,
                    new SequenceShuffle(
                        SubTree(Val.Value(() => one)),
                        SubTree(Val.Value(() => two)),
                        SubTree(Val.Value(() => three)),
                        SubTree(Val.Value(() => four)),
                        SubTree(Val.Value(() => five)))));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) == true)
        {
            base.StartTree(this.Tree());
        }
    }
}
