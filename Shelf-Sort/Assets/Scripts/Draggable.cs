using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private float mouseDragSpeed = 0.0001f;
    private Camera mainCam;
    private Vector3 initialPos;
    private Vector3 velocity = Vector3.zero;
    private bool validPos = false;

    private Vector3 pos;

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
        gameObject.TryGetComponent<Rigidbody2D>(out var rb);
        Ray ray = mainCam.ScreenPointToRay(Pointer.current.position.ReadValue());
        Vector3 direction = ray.GetPoint(initialDistance) - transform.position;
        rb.MovePosition(Vector3.SmoothDamp(transform.position, ray.GetPoint(initialDistance), 
             ref velocity, mouseDragSpeed));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if overlap 
        transform.position = validPos ? pos : initialPos;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ShelfSlot") && collider.gameObject.GetComponent<ShelfSlotManager>().IsEmpty()) {
            validPos = true;
            pos = collider.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        validPos = false;
    }
}
