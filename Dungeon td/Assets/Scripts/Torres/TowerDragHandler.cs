using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TowerDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    public GameObject towerPrefab; // Asigna tu prefab de torre aquí
    private GameObject currentTower;
    public Boolean isDragging = false;
    public int precio;
    public ControlJuego controlJuego;
    public Tilemap BloquedZonesTilemap;
    public TileBase blockedTile;
    public Tilemap ValidZonesTilemap;
    public TileBase ValidTile;
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
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (towerPrefab.GetComponent<Disparo_base>() != null)
        {
            controlJuego.infot.text = towerPrefab.GetComponent<Disparo_base>().informacion + " Precio:" + precio;
        }
        if (towerPrefab.GetComponent<Granja>() != null)
        {
            controlJuego.infot.text = towerPrefab.GetComponent<Granja>().informacion + " Precio " + precio;
        }
        if (towerPrefab.GetComponent<Trampa>() != null)
        {
            controlJuego.infot.text = towerPrefab.GetComponent<Trampa>().informacion + " Precio " + precio;
        }
        if (towerPrefab.GetComponent<PsycoKiller>() != null)
        {
            controlJuego.infot.text = towerPrefab.GetComponent<PsycoKiller>().informacion + " Precio " + precio;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

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
        Vector3Int cellPosition = BloquedZonesTilemap.WorldToCell(position);

        // Obtener el tile en esa posición de celda
        TileBase tileAtPosition = BloquedZonesTilemap.GetTile(cellPosition);
        // Convertir la posición del mundo a la posición de celda del Tilemap
        Vector3Int cellPositionvalid = ValidZonesTilemap.WorldToCell(position);

        // Obtener el tile en esa posición de celda
        TileBase tileAtPositionvalid = ValidZonesTilemap.GetTile(cellPositionvalid);
        // Verificar si el tile es el permitido para colocar el personaje
        if (tileAtPosition != blockedTile && tileAtPositionvalid == ValidTile)
        {
            // Verificar si hay otro objeto "Personaje" en la misma posición 
            float radius = 0.5f;
            // Ajusta este valor según el tamaño de tu torre 
            Collider2D[] collidersAtPosition = Physics2D.OverlapCircleAll(position, radius);
            foreach (Collider2D collider in collidersAtPosition)
            {
                if (collider.gameObject.CompareTag("Personaje") && collider.gameObject != currentTower)
                {
                    return false; // Es una zona permitida
                }
            }
            return true; // Es una zona permitida

        }
        return false; // No es una zona permitida
    }
}