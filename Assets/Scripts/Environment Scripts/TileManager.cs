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
        Vector3Int worldPosition = new Vector3Int((int)((position.x))/3, (int)((position.y))/3,0);
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
        Vector3Int worldPosition = new Vector3Int((int)((position.x))/3, (int)((position.y))/3,0);
        if(isPlantable(position)){
            cropMap.SetTile(worldPosition, tileToPlace);
            GameManager.instance.inventoryUI.Consume(GameManager.instance.player.activeItemIndex);
        }
    }

    public void PlowHere(Vector3Int position)
    {
        Vector3Int worldPosition = new Vector3Int((int)((position.x))/3, (int)((position.y))/3,0);
        ruleTileMap.SetTile(worldPosition, interactedTile);
    }

    public bool isPlantable(Vector3Int position)
    {
        Vector3Int worldPosition = new Vector3Int((int)((position.x))/3, (int)((position.y))/3,0);
        TileBase tile = ruleTileMap.GetTile(worldPosition);
        if (tile!=null)
        {
            if (tile.name == "Plowed")
                {return true; }          }        
        return false;
    }

    public bool CanInteract(Vector3Int position)
    {
        Vector3Int worldPosition = new Vector3Int((int)((position.x))/3, (int)((position.y))/3,0);
        TileBase tile = cropMap.GetTile(worldPosition);
        if (tile!=null)
        {
            return true; 
        }        
        return false;
    }

    public void Interact(Vector3Int position)
    {
        Vector3Int worldPosition = new Vector3Int((int)((position.x))/3, (int)((position.y))/3,0);
        if(CanInteract(position))
        {
            
            Item harvest = cropMap.GetInstantiatedObject(worldPosition).GetComponent<Plant>().grownVersion;
            if (cropMap.GetInstantiatedObject(worldPosition).GetComponent<Plant>().isHarvestable){
                if (GameManager.instance.player.inventory.Add(harvest))
                {
                    Destroy(cropMap.GetInstantiatedObject(worldPosition)); 
                    GameManager.instance.toolbarUI.Refresh();
                }
            }
            
             
        }
    }
}
