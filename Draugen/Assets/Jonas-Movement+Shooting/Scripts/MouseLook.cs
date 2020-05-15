using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform cams;

    [SerializeField] private static bool cursorLocked = true;

    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    [SerializeField] private float maxAngle;
    private Quaternion camCenter;

    void Start()
    {
        camCenter = cams.localRotation;
    }

    
    void Update()
    {
        SetY();
        SetX();
        UpdateLockCursor();
    }


    void SetY()
    {
        float LookInput = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        Quaternion QLook = Quaternion.AngleAxis(LookInput, -Vector3.right);
        Quaternion DeltaLook = cams.localRotation * QLook;

        if(Quaternion.Angle(camCenter, DeltaLook) < maxAngle)
        {
            cams.localRotation = DeltaLook;
        }
        
            
    }


    void SetX()
    {
        float LookInput = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        Quaternion QLook = Quaternion.AngleAxis(LookInput, Vector3.up);
        Quaternion DeltaLook = player.localRotation * QLook;
        player.localRotation = DeltaLook;
    }


    void UpdateLockCursor()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;
            }

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = true;
            }
        }
    }

}
