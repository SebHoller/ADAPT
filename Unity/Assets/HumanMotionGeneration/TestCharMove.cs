using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharMove : MonoBehaviour
{
    CharacterMovement charMovement;
    // Start is called before the first frame update
    void Start()
    {
        this.charMovement = gameObject.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) == true)
        {
            string path = "C:\\Projekte\\ADAPT\\Unity\\Assets\\HumanMotionGeneration\\charMovementsIn.txt";
            charMovement.InputCharacterMovements(path);
        }
    }
}
