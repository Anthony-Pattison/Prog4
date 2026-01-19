using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBillboard : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
