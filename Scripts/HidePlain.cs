using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;



[RequireComponent(typeof(ARPlaneManager))]

public class HidePlain : MonoBehaviour
{


    private ARPlaneManager planemanager;

    [SerializeField]

    private Text toggleButtonText;

    private void Awake()
    {
        planemanager = GetComponent<ARPlaneManager>();
        toggleButtonText.text = "Disable";
    }

    public void TogglePlaneDetection()
    {
        planemanager.enabled = !planemanager.enabled;
        string toggleButtonMessage = "";

        if (planemanager.enabled)
        {
            toggleButtonMessage = "Disable";
            SetAllPlanesActive(true);
        }
        else
        {
            toggleButtonMessage = "Enable";
            SetAllPlanesActive(false);
        }
        toggleButtonText.text = toggleButtonMessage;
    }

    private void SetAllPlanesActive(bool value)
    {
        foreach(var plane in planemanager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }









    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
