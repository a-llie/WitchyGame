using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tilemap ruleTileMap;
    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private RuleTile interactedTile;
    [SerializeField] private Tilemap cropMap;


    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);
            if (tile != null && tile.name == "Interact_Visible")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
            
        }

        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);
            if (tile != null && tile.name == "Interact_Visible")
            {
                Debug.Log(tile.name + position);
            }
        }
    }


    public bool isInteractable(Vector3Int position)
    {
        Vector3Int worldPosition = divideByThree(position);
        TileBase tile = interactableMap.GetTile(worldPosition);
        if (tile!=null)
        {
            if (tile.name == "Interact")
                {return true;}  
        }
        
        return false;
    }

    public void TryPlowing(Vector3Int position)
    {
        if(isInteractable(position))
        {
            PlowHere(position);
        }
    }
    
    public void PlantHere(Vector3Int position, RuleTile tileToPlace)
    {
        Vector3Int worldPosition = divideByThree(position);
        if(isPlantable(worldPosition) && isEmpty(worldPosition)){
            cropMap.SetTile(worldPosition, tileToPlace);
            GameManager.instance.inventoryUI.Consume(GameManager.instance.player.activeItemIndex);
        }
    }

    public void PlowHere(Vector3Int position)
    {
        Vector3Int worldPosition = divideByThree(position);
        ruleTileMap.SetTile(worldPosition, interactedTile);
    }

    public bool isPlantable(Vector3Int position)
    {
        TileBase tile = ruleTileMap.GetTile(position);
        if (tile!=null)
        {
            if (tile.name == "Plowed")
                {return true; }          }        
        return false;
    }

    public bool CanInteract(Vector3Int position)
    {
        TileBase tile = cropMap.GetTile(position);
        if (tile!=null)
        {
            return true; 
        }        
        return false;
    }

    public bool isEmpty(Vector3Int position)
    {
        TileBase tile = cropMap.GetTile(position);
        if (tile==null)
        {
            return true; 
        }        
        return false;
    }

    public void Interact(Vector3Int position)
    {
        Vector3Int worldPosition = divideByThree(position);
        if(CanInteract(worldPosition))
        {
            Plant plant =  cropMap.GetInstantiatedObject(worldPosition).GetComponent<Plant>();
            plant.Interact(worldPosition);
        }
    }

    public void DestroyTile(Vector3Int position)
    {
        cropMap.SetTile(position, null);
    }

    public Vector3Int divideByThree(Vector3Int position)
    {
        return new Vector3Int((int)((position.x))/3, (int)((position.y))/3,0);
    }

}
