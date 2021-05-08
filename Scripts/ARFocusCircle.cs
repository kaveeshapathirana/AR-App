using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.EventSystems;

public class ARFocusCircle : MonoBehaviour
{
    //public GameObject scanText;
    //public GameObject placeText;

    int objIndex;

    

    public GameObject placementIndicator;
    //private GameObject carParent;

    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private bool placementIndicatorEnabled = true;

    bool isUIHidden = false;

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        //scanText.SetActive(true);
        //placeText.SetActive(false);
    }

    void Update()
    {

        if (placementIndicatorEnabled == true)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }

        //if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    PlaceObject();
        //}
    }

    public void HideUI() {

        if (isUIHidden == false)
        {
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }

            placementIndicatorEnabled = false;
            placementIndicator.SetActive(false);

        
        }
    }

    public void PlaceObject() {

        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        for (int i = 0; i < buttons.Length; i++) {

            if (buttons[i].name == buttonName) {

                objIndex = i;
            }
        }

    }

    

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);

            foreach (var button in buttons) {
                button.gameObject.SetActive(true);
            }

            //scanText.SetActive(false);
            //placeText.SetActive(true);

            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        
        }
    }

    private void UpdatePlacementPose()
    {
       
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
