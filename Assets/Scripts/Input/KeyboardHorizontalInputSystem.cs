using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Keyboard Horizontal Axis ", menuName = "Input System / Keyboard Horizontal")]
public class KeyboardHorizontalInputSystem : InputSystem
{
    public delegate void LogEventHandler(string str);
    public static event LogEventHandler OnLogged;
    public override float GetInput()
    {
        return Input.GetAxis("Horizontal");
    }

    public override void StartInput()
    {
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        if (rightHandDevices.Count >= 1)
        {
            OnLogged?.Invoke("Found XR Input tool");
        }
        else OnLogged?.Invoke("NO XR Input tool");

    }
}
