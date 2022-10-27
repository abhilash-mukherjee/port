using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

[CreateAssetMenu(fileName = "New Keyboard Horizontal Axis ", menuName = "Input System / Keyboard Horizontal")]
public class KeyboardHorizontalInputSystem : InputSystem
{

    public delegate void LogEventHandler(string str);
    public static event LogEventHandler OnLogged;
    private List<UnityEngine.XR.InputDevice> rightHandDevices;
    public override float GetInput()
    {
        if(rightHandDevices.Count > 1)
        {
            var x = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
            OnLogged?.Invoke($"x inp = {x}");
            return x;

        }
        return Input.GetAxis("Horizontal");
    }
 

    public override void StartInput()
    {
        rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        if (rightHandDevices.Count >= 1)
        {
            OnLogged?.Invoke("Found XR Input tool");
        }
        else OnLogged?.Invoke("NO XR Input tool");

    }
}
