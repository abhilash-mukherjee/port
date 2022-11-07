using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField]
    private Transform OperatorXROrigin, SailorXROrigin;
    [SerializeField]
    private OVRManager oVRManager;
    private bool m_toggler = true;
    private void Start()
    {
        oVRManager.gameObject.transform.SetParent(SailorXROrigin);
        oVRManager.gameObject.transform.localPosition = Vector3.zero;
        oVRManager.gameObject.transform.localRotation = Quaternion.identity;
        m_toggler = true; 
    }
    public void OnViewToggled() 
    {
        oVRManager.gameObject.transform.SetParent(m_toggler == true  ? OperatorXROrigin : SailorXROrigin);
        m_toggler = !m_toggler;
        oVRManager.gameObject.transform.localPosition = Vector3.zero;
        oVRManager.gameObject.transform.localRotation = Quaternion.identity;
    }
}
