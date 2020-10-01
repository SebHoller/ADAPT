using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSTL : MonoBehaviour
{
    AddObject addObject;
    // Start is called before the first frame update
    void Start()
    {
        this.addObject = gameObject.GetComponent<AddObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) == true)
        {
            string path = "C:\\Projekte\\ADAPT\\Unity\\Assets\\HumanMotionGeneration\\10260_Workbench_max8_v1_iterations-2.stl";
            this.addObject.IportSTL(path, true);
        }
        if (Input.GetKeyDown(KeyCode.K) == true)
        {
            string path = "C:\\Projekte\\ADAPT\\Unity\\Assets\\HumanMotionGeneration\\13604_Drill_Press_v1_L2.stl";
            this.addObject.IportSTL(path, true);
        }
    }
}
