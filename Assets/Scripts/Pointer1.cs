using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Pointer1 : MonoBehaviour
{
    public float m_Distance = 25.0f;
    public LineRenderer m_LineRenderer = null;
    public LayerMask m_Everythingmask = 0;
    public LayerMask m_InteractableMask = 0;
    public UnityAction<Vector3, GameObject> OnPointerUpdate = null;

    private Transform m_CurrentOrigin = null;
    private GameObject m_CurrentObject = null;


    private void Awake()
    {
        Player_Events.OnControllerSource += UpdateOrigin;
        Player_Events.OnTouchpadDown += ProcessTouchPadDown;
    }
    private void Start()
    {
        SetLineColor();
    }
    private void OnDestroy()
    {
        Player_Events.OnControllerSource -= UpdateOrigin;
        Player_Events.OnTouchpadDown -= ProcessTouchPadDown;
    }
    private void Update()
    {
        Vector3 hitPoint = UpdateLine();

        m_CurrentObject = UpdatePointerStatus();

        if (OnPointerUpdate != null)
            OnPointerUpdate(hitPoint, m_CurrentObject);

    }
    private Vector3 UpdateLine()
    {
        // Create ray
        RaycastHit hit = CreateRayCast(m_Everythingmask);

        //Default End
        Vector3 endPositon = m_CurrentOrigin.position + (m_CurrentOrigin.forward * m_Distance);

        //Check hit
        if (hit.collider != null)
            endPositon = hit.point;

        //Set position
        m_LineRenderer.SetPosition(0, m_CurrentOrigin.position);
        m_LineRenderer.SetPosition(1, endPositon);

        return endPositon;

    }

    private void UpdateOrigin(OVRInput.Controller controller, GameObject controllerObject)
    {
        //Set Origin of pointer
        m_CurrentOrigin = controllerObject.transform;

        //Is the laser visible?
        if (controller == OVRInput.Controller.Touchpad)
        {
            m_LineRenderer.enabled = false;
        }
        else
        {
            m_LineRenderer.enabled = true;
        }

    }
    private GameObject UpdatePointerStatus()
    {
        //Create ray
        RaycastHit hit = CreateRayCast(m_InteractableMask);
        //Check hit
        if (hit.collider)
            return hit.collider.gameObject;
        //Return
        return null;
    }

    private RaycastHit CreateRayCast(int layer)
    {
        RaycastHit hit;
        //Ray ray = new Ray(m_CurrentOrigin.position, m_CurrentOrigin.forward);
        Ray ray = new Ray(m_CurrentOrigin.position, m_CurrentOrigin.forward);
        //Physics.Raycast(ray, out hit, m_Distance, layer);
        Physics.Raycast(ray, out hit, m_Distance, layer);

        return hit;

    }
    private void SetLineColor()
    {
        if (!m_LineRenderer)
            return;

        Color endColor = Color.white;
        endColor.a = 0.0f;

    }
    private void ProcessTouchPadDown()
    {
        if (!m_CurrentObject)
            return;

        Interactable interactable = m_CurrentObject.GetComponent<Interactable>();
        interactable.pressed();
    }
}
