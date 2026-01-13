using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.UI;

public class RobotBattery : MonoBehaviour
{
    [HideInInspector] public float batteryPercent = 1f;
    [SerializeField] private Image batteryPercentUI;

    void Update()
    {
        batteryPercent = GetComponent<Blackboard>().GetVariableValue<float>("currentCharge")/100;
        batteryPercentUI.fillAmount = batteryPercent;
    }
}
