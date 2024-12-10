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
    public List<TileBase> ValidTile;
    public Color original;

    void Update()
    {
        //Si le ds clic derecho se borra la torre mietras la arrrastras y no cuesta dinero
        if (isDragging)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(currentTower); 
                currentTower = null; 
            }
        }
    }
    //Si pones el raton encima hace lo indicado para cada torre dependiendo de su componente
    //pero todos muestran la informacion y el precio
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
    //Metodo que se activas si empiezas a arrastrar el objeto asociado en este caso un button
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Si el precio es menor que el dinero que tiene el jugador deja que se arrastre
        if (precio <= controlJuego.dinero)
        {
            // Instanciar la torre en la posición del mouse
            isDragging = true;
            currentTower = Instantiate(towerPrefab);
            currentTower.transform.position = GetMouseWorldPosition();//coloca la torre encima del cursor
            currentTower.SetActive(true); // Mostrar la torre al empezar a arrastrar
            original = currentTower.GetComponent<SpriteRenderer>().color;//Coje su color
        }
    }
    //Se activa mientras se arrastra
    public void OnDrag(PointerEventData eventData)
    {
        if (currentTower != null)
        {
            currentTower.transform.position = GetMouseWorldPosition();
            //Si la posicion no es valida se colorea de color rojo
            //Si es valida se colorea de blanco
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
    //Se activa cundo sueltas el objeto arastrado
    public void OnEndDrag(PointerEventData eventData)
    {
        if (currentTower != null)
        {
            // Si la posicion es valida se coloca y se le coloca su color orijinal
            //Si no se elimina
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
    //Devuelve un vector3 con la posicion del mouse
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = 10f; // Distancia desde la cámara
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
    //Mediante diferentes metodos detecta si la posicion es valida o no
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
        if (tileAtPosition != blockedTile && ValidTile.Contains(tileAtPositionvalid))
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