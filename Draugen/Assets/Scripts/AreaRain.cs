using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaRain : MonoBehaviour
{
    [SerializeField] private GameObject Rain;
    [SerializeField] private int Hide;
    [SerializeField] private int Show;



 
    void Start()
    {
        StartCoroutine(HideObject());
    }

    IEnumerator HideObject()
    {
        while (true)
        {

            yield return new WaitForSeconds(Hide);
            Rain.SetActive(false);
            yield return new WaitForSeconds(Show);
            Rain.SetActive(true);
        }
    }


}


