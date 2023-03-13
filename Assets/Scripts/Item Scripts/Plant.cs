using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Plant : Equipment
{
    public CropData asPlant;
    public Sprite plantIcon; 
    public SpriteRenderer SpriteRenderer; 
    public int currentSprite = 0; 
    public bool isHarvestable; 
    public Item grownVersion; 
    
    public override void Use()
    {
        GameManager.instance.player.Plant(); 
        
    }

    public void Interact(Vector3Int worldPosition)
    {
        if (isHarvestable)
        {
            if (GameManager.instance.player.inventory.Add(grownVersion))
                {
                    Destroy(this); 
                    GameManager.instance.tileManager.DestroyTile(worldPosition);
                    GameManager.instance.toolbarUI.Refresh();
                }
        }
    }

    void Start(){
        isHarvestable = false;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = asPlant.stageSprites[0];
        StartCoroutine(grow());
    }

    IEnumerator grow()
    {
        while (currentSprite < asPlant.stageSprites.Length - 1)
        {
            yield return new WaitForSeconds(1f);
            currentSprite ++; 
            SpriteRenderer.sprite = asPlant.stageSprites[currentSprite]; 
        }

        yield return new WaitForSeconds(1f);
        SpriteRenderer.sprite = asPlant.harvestSprite;
        isHarvestable = true;
    }

}
