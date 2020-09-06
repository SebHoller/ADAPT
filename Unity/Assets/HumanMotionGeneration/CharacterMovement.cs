﻿using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    string[] actions;
    string[] parameter;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("Please enter the path to the text file with actions:");
        string path = Console.ReadLine();
        string[] lines = ReadFile.ReadLines(path);
        actions = new string[lines.Length];
        parameter = new string[lines.Length];
        for(int i=0; i<lines.Length; i++)
        {
            string line = lines[i];
            string[] split = line.Split(':');
            actions[i] = split[0];
            parameter[i] = split[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        string action = actions[counter];
        string param = parameter[counter];
        Character character = gameObject.AddComponent<Character>();
        Vector3 vec;
        switch (action)
        {
            case "wait":
                System.Threading.Thread.Sleep(Int32.Parse(param));
                break;
            case "move":
                string[] split = param.Split(',');
                switch(split.Length)
                {
                    case 2:
                        vec = new Vector3(float.Parse(split[0]), float.Parse(split[1]));
                        break;
                    case 3:
                        vec = new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
                        break;
                    default:
                        vec = new Vector3();
                        break;
                }
                character.NavGoTo(vec);
                break;
            case "leftHand":
            case "rightHand":
                split = param.Split(',');
                vec = new Vector3();
                switch (split.Length)
                {
                    case 2:
                        vec = new Vector3(float.Parse(split[0]), float.Parse(split[1]));
                        break;
                    case 3:
                        vec = new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
                        break;
                    default:
                        vec = new Vector3();
                        break;
                }
                character.ReachFor(vec);
                break;
            default:
                break;
        }
        counter++;
    }
}
