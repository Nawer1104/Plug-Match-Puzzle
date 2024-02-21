using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool _dragging;

    private Vector2 _offset;

    public static bool mouseButtonReleased;

    public GameObject pointer;

    public GameObject[] obj_array;

    private void Awake()
    {
        pointer.SetActive(false);
    }

    private void OnMouseDown()
    {
        _dragging = true;
        _offset = GetMousePos() - (Vector2)transform.position;

        foreach(GameObject gj in obj_array)
        {
            gj.GetComponent<SpriteRenderer>().sortingOrder += 2;
        }
    }

    private void OnMouseDrag()
    {
        if (!_dragging) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;

        pointer.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
        _dragging = false;
        pointer.SetActive(false);
        foreach (GameObject gj in obj_array)
        {
            gj.GetComponent<SpriteRenderer>().sortingOrder -= 2;
        }
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}