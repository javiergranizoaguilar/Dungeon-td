using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TowerDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject towerPrefab; // Asigna tu prefab de torre aquí
    private GameObject currentTower;
    public Boolean isDragging = false;
    public int precio;
    public ControlJuego controlJuego;
    public Tilemap allowedZonesTilemap;
    public TileBase blockedTile;
    public Color original;

    void Update()
    {
        if (isDragging)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(currentTower); // Eliminar la torre si no es válida
                currentTower = null; // Limpiar referencia
            }
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        controlJuego.infot.text="Info: lo mas basico \nPrecio: 100";
        if (precio <= controlJuego.dinero)
        {
            // Instanciar la torre en la posición del mouse
            isDragging = true;
            currentTower = Instantiate(towerPrefab);
            currentTower.transform.position = GetMouseWorldPosition();
            currentTower.SetActive(true); // Mostrar la torre al empezar a arrastrar
            original = currentTower.GetComponent<SpriteRenderer>().color;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentTower != null)
        {
            currentTower.transform.position = GetMouseWorldPosition();
            if (IsPositionValid(currentTower.transform.position))
            {
                currentTower.GetComponent<SpriteRenderer>().color = Color.white;

            }
            else
            {
                currentTower.GetComponent<SpriteRenderer>().color = Color.red;

            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (currentTower != null)
        {
            // Aquí puedes verificar si la posición es válida
            if (IsPositionValid(currentTower.transform.position))
            {
                isDragging = false;
                // La torre permanece visible
                currentTower.GetComponent<SpriteRenderer>().color = original;
                controlJuego.dinero -= precio;
            }
            else
            {
                Destroy(currentTower); // Eliminar la torre si no es válida
            }
            currentTower = null; // Limpiar referencia
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = 10f; // Distancia desde la cámara
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    private bool IsPositionValid(Vector3 position)
    {
        // Convertir la posición del mundo a la posición de celda del Tilemap
        Vector3Int cellPosition = allowedZonesTilemap.WorldToCell(position);

        // Obtener el tile en esa posición de celda
        TileBase tileAtPosition = allowedZonesTilemap.GetTile(cellPosition);

        // Verificar si el tile es el permitido para colocar el personaje
        if (tileAtPosition != blockedTile)
        {
            return true; // Es una zona permitida
        }

        return false; // No es una zona permitida
    }
}