using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCapsule : MonoBehaviour
{

    CapsuleCollider playerCol;
    float originalHeight;
    [SerializeField] private float reduceHeight;



    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        originalHeight = playerCol.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Crouch();
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            GoUp();
    }


    void Crouch()
    {
        playerCol.height = reduceHeight;
    }

    void GoUp()
    {
        playerCol.height = originalHeight;
    }

}
