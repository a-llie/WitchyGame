using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveSpeed = 10f;


    private float movementX;
    private float movementY; 
    private float runX = 1; 
    private Vector3 tempScale;
    private Animator anim; 
    private Vector3 direction; 
    private bool facingRight; 

    public Inventory inventory;
    public int inventorySize = 20;
    public int toolbarSize = 8;
    public string activeItem; 
    public int xOffset;
    public int activeItemIndex; 

    private void Awake()
    {
        inventory = new Inventory(inventorySize);
        anim = GetComponent<Animator>();
    }



    void Update()
    {
        //activeItem = inventory.equipped[GameManager.instance.toolbarUI.activeItem].itemName;
        if (Input.GetKeyDown(KeyCode.Space) && activeItem != null && inventory.equipped[activeItemIndex].itemName != "")
        {
            Tool.use(activeItem);
        }
        HandleFacingDirection();
        HandlePlayerAnimation();
        HandlePlayerMovement();
    }



    void HandlePlayerMovement()
    {
        if (Input.GetKeyDown("left shift") ){
            runX = 1.75f;
        }else if (Input.GetKeyUp("left shift")) 
        {
            runX = 1;
        }
        movementX = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS);
        movementY = Input.GetAxisRaw(TagManager.VERTICAL_AXIS);
        direction = new Vector3(movementX, movementY).normalized;


    }

    void HandleFacingDirection()
    {
        tempScale = transform.localScale;

        if (movementX > 0)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
            facingRight = true;
        }
        else if (movementX < 0)
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
            facingRight = false;
        }
        transform.localScale = tempScale;
    }

    void HandlePlayerAnimation()
    {
        if (Input.GetKeyDown("left shift") ){
            anim.SetBool(TagManager.RUN_ANIMATION_PARAMETER, true);
            movementX *=2;
        }else if (Input.GetKeyUp("left shift")) 
        {
            anim.SetBool(TagManager.RUN_ANIMATION_PARAMETER, false);
        }
        if (movementX != 0 || movementY !=0){
            anim.SetBool(TagManager.WALK_ANIMATION_PARAMETER, true);
        }
        else{
            anim.SetBool(TagManager.WALK_ANIMATION_PARAMETER, false);
        }
    }


    void FixedUpdate()
    {
        transform.position += direction * moveSpeed * runX * Time.deltaTime;
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 3.25f;
        if (spawnOffset.y < 1) spawnOffset.y++;
        spawnOffset.x = facingRight? Mathf.Abs(spawnOffset.x) : -Mathf.Abs(spawnOffset.x);
        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);    
        droppedItem.rb.AddForce(spawnOffset * 5f, ForceMode2D.Impulse);
    }

    public void Plow()
    {
        Debug.Log("Plow");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.tileManager.TryPlowing(OffsetPosition());
        }
    }

    public void Plant()
    {
        Debug.Log("planting");
        GameManager.instance.tileManager.PlantHere(OffsetPosition(), GameManager.instance.itemManager.GetSeedByName(activeItem));
    }


    public void SwitchActiveItem(int index)
    {
       activeItem = inventory.equipped[index].itemName;
       activeItemIndex = index; 
    }


    public Vector3Int OffsetPosition()
    {
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        int OffsetX = facingRight? x + xOffset   : x - xOffset;
        int yOffset = y - 4;
        return new Vector3Int(OffsetX,yOffset,0);
    }


}
