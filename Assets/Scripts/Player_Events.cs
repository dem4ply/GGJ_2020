using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Events : MonoBehaviour
{
    #region Events
    public static UnityAction OnTouchpadUp = null;
    public static UnityAction OnTouchpadDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> OnControllerSource = null;
    #endregion
    #region Anchors
    public GameObject m_Rightanchor;
    public GameObject m_Leftanchor;
    public GameObject m_Headanchor;

    #endregion

    #region Input
    private Dictionary<OVRInput.Controller, GameObject> m_ControllerSets = null;
    //Get the last input source
    private OVRInput.Controller m_InputSourcce = OVRInput.Controller.None;
    //Track whatever active controller is active
    private OVRInput.Controller m_Controller = OVRInput.Controller.None;
    private bool m_InputActve = true;
    #endregion

    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

        m_ControllerSets = CreateControllerSets();
    }
    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;

    }
    // Update is called once per frame
    void Update()
    {
        //Check for active input
        if (!m_InputActve)
        {
            return;
        }
        //Check if controller exist
        //check for input source
        CheckInputSource();

        //Check for actual input
        Input();

    }

    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = m_Controller;

        // Right remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            controllerCheck = OVRInput.Controller.RTrackedRemote;
        // Left remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.LTrackedRemote;

        // If not remote, headset
        if (!OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) &&
            !OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            controllerCheck = OVRInput.Controller.Touchpad;

        //Update
        m_Controller = UpdateSource(controllerCheck, m_Controller);

    }
    private void CheckInputSource()
    {
        /*//Left remote
        if(OVRInput.GetDown(OVRInput.Button.Any,OVRInput.Controller.LTrackedRemote))
        {

        }

        //Right Remote
        if (OVRInput.GetDown(OVRInput.Button.Any, OVRInput.Controller.RTrackedRemote))
        {

        }

        //Headset
        if (OVRInput.GetDown(OVRInput.Button.Any, OVRInput.Controller.Touchpad))
        {

        }*/

        //Update
        m_Controller = UpdateSource(OVRInput.Controller.Active, m_Controller);

    }
    private void Input()
    {
        //Touchpad down
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            if (OnTouchpadDown != null)
                OnTouchpadDown();

        }
        //Touchpad up
        if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
        {
            if (OnTouchpadUp != null)
                OnTouchpadUp();
        }

    }
    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous)
    {
        // Check if values are the same, return 
        if (check == previous)
            return previous;
        //Get controller object
        GameObject controllerObject = null;
        m_ControllerSets.TryGetValue(check, out controllerObject);

        //if no controller object set to the head
        if (controllerObject == null)
            controllerObject = m_Headanchor;
        //Send out event
        if (OnControllerSource != null)
            OnControllerSource(check, controllerObject);

        //Return new value
        return check;
    }

    private void PlayerFound()
    {
        m_InputActve = true;
    }
    private void PlayerLost()
    {
        m_InputActve = false;
    }
    private Dictionary<OVRInput.Controller,GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            { OVRInput.Controller.LTrackedRemote, m_Leftanchor},
            { OVRInput.Controller.RTrackedRemote, m_Rightanchor},
            { OVRInput.Controller.Touchpad, m_Headanchor}         

        };
        return newSets;
    }
}
