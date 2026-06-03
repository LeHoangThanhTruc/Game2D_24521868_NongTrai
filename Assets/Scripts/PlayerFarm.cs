using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEditor.VersionControl;
public class PlayerFarm : MonoBehaviour
{
    public Tilemap tm_Ground;
    public Tilemap tm_Grass;
    public Tilemap tm_Forest;
    public TileBase tb_Ground;
    public TileBase tb_Grass;
    public TileBase tb_Forest;

    private InventoryManger inventoryManger;

    private void Start()
    {
        inventoryManger = GameObject.Find("InventoryManager").GetComponent<InventoryManger>();
    }
    private void Update()
    {
        HandleFarmAction();
    }
    public void HandleFarmAction()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Vector3Int cellPos = tm_Ground.WorldToCell(transform.position);
            Debug.Log("Cell pos: " + cellPos);

            TileBase currTileBase = tm_Grass.GetTile(cellPos);

            if ((currTileBase == tb_Grass))
            {
                tm_Grass.SetTile(cellPos, tile: null);
            }

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Vector3Int cellPos = tm_Ground.WorldToCell(transform.position);
            Debug.Log("Cell pos: " + cellPos);

            TileBase currTileBase = tm_Grass.GetTile(cellPos);

            if ((currTileBase == null))
            {
                tm_Forest.SetTile(cellPos, tb_Forest);
            }
        }
        //Thu hoạch
        if (Input.GetKeyDown(KeyCode.M))
        {
            Vector3Int cellPos = tm_Ground.WorldToCell(transform.position);
            Debug.Log("Cell pos: " + cellPos);

            TileBase currTileBase = tm_Forest.GetTile(cellPos);
            if ((currTileBase != null))
            {
                tm_Grass.SetTile(cellPos, tb_Grass);
                tm_Forest.SetTile(cellPos, tile: null);
                //Thêm vào túi đồ
                InventoryItems itemFlower = new InventoryItems();
                itemFlower.name = "Flower";
                itemFlower.description = "A beautiful flower.";

                Debug.Log(itemFlower.ToString());
                inventoryManger.AddInventoryItem(itemFlower);
            }
        }
    }
}
