using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Keyboard Vertical Axis ", menuName = "Input System / Keyboard Vertical")]
public class KeyboardVerticalInputSystem : InputSystem
{
    public override float GetInput()
    {
        return Input.GetAxis("Vertical");
    }

    public override void StartInput()
    {
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count >= 1)
        {
            Debug.Log("Found XR Input tool");
        }
        else Debug.Log("Found NOO  Input tool");

    }
}
