using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private float mouseDragSpeed = 0.01f;
    private Camera mainCam;
    private Vector3 initialPos;
    private Vector3 velocity = Vector3.zero;
    private bool validPos = false;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        initialPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float initialDistance = Vector3.Distance(transform.position, mainCam.transform.position);
        Ray ray = mainCam.ScreenPointToRay(Pointer.current.position.ReadValue());
        transform.position = Vector3.SmoothDamp(transform.position, ray.GetPoint(initialDistance), 
            ref velocity, mouseDragSpeed);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = validPos ? transform.position : initialPos;
    }

}
