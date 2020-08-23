using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCoordinator : ShadowCoordinator
{
    protected ShadowTransform[] buffer1 = null;
    protected ShadowLeanController lean = null;
    // Start is called before the first frame update
    void Start()
    {
        this.buffer1 = this.NewTransformArray();
        this.lean = this.GetComponent<ShadowLeanController>();
        this.ControlledStartAll();
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateCoordinates();
        this.lean.ControlledUpdate();
        this.lean.Encode(this.buffer1);
        Shadow.ReadShadowData(this.buffer1, this.transform.GetChild(0), this);
    }
}
