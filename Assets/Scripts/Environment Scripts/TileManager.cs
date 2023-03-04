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
    [SerializeField] public Tilemap cropMap;
    [SerializeField] public RuleTile garlicTile;


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
}
