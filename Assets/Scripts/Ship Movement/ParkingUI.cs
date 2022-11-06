using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingUI : MonoBehaviour
{
    [SerializeField] private GameObject glow;
    [SerializeField] private string ID;
    static ParkingUI selectedParking;
    private void OnEnable()
    {
        InteractableMapElement.OnElementPressed += AddGlow;
    }

    private void AddGlow(string ID)
    {
        if (ID != this.ID) return;
        if(selectedParking != null) selectedParking.RemoveGlow();
        glow.SetActive(true);
        selectedParking = this;
    }

    private void RemoveGlow()
    {
        glow.SetActive(false);
    }

    private void OnDisable()
    {
        InteractableMapElement.OnElementPressed -= AddGlow;
        
    }
}