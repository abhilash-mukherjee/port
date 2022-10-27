using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Keyboard Vertical Axis ", menuName = "Input System / Keyboard Vertical")]
public class KeyboardVerticalInputSystem : InputSystem
{
    public delegate void LogEventHandler(string str);
    public static event LogEventHandler OnLogged;
    private List<UnityEngine.XR.InputDevice> leftHandDevices;
    public override float GetInput()
    {
        OVRInput.Update();
        if (leftHandDevices.Count > 1)
        {
            var y = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
            OnLogged?.Invoke($"x inp = {y}");
            return y;

        }
        return Input.GetAxis("Vertical");
    }

    public override void StartInput()
    {
        leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count >= 1)
        {
            Debug.Log("Found XR Input tool");
        }
        else Debug.Log("Found NOO  Input tool");

    }
}
