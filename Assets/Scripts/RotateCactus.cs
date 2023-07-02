using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCactus : MonoBehaviour
{

    void Start()
    {
        // Get all child transforms
        Transform[] children = GetComponentsInChildren<Transform>();

        // Set random rotation for each child transform
        foreach (Transform child in children)
        {
            // Ignore the parent object
            if (child == transform)
                continue;

            // Generate a random rotation
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            // Apply the random rotation to the child transform
            child.rotation = randomRotation;
        }
    }
}

