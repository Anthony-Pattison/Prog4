using System.Collections;
using UnityEngine;

public class TrashOpeningAnim : MonoBehaviour
{
    public float OpenAngle;
    public float CloseAngle;
    public float CloseSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartAnim()
    {
        StartCoroutine(TrashLid());
    }

    IEnumerator TrashLid()
    {
        float xRotation = 0;
        while (xRotation < OpenAngle)
        {
            xRotation += CloseSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(xRotation, 0, 0);
            yield return null;
        }

        while (xRotation > CloseAngle)
        {
            xRotation -= CloseSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(xRotation, 0, 0);
            yield return null;
        }
    }
}
