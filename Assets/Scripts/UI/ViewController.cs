using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField] private OVRManager SailorView, OperatorView;
    private void Awake()
    {
        OperatorView.gameObject.SetActive(false);
    }
    public void OnViewToggled() 
    {
        SailorView.gameObject.SetActive(!(SailorView.gameObject.activeSelf));
        OperatorView.gameObject.SetActive((!OperatorView.gameObject.activeSelf));
    }
}
