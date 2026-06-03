using PolyAndCode.UI;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManger : MonoBehaviour, IRecyclableScrollRectDataSource
{
    [SerializeField]
    RecyclableScrollRect _recyclableScrollRect;
    [SerializeField]
    private int _dataLength;

    public GameObject inventoryGameObject;
    //Dummy data List
    private List<InventoryItems> _ivenItems = new List<InventoryItems>();

    //Recyclable scroll rect's data source must be assigned in Awake.
    private void Awake()
    {
        _recyclableScrollRect.DataSource = this;
    }
    
    public int GetItemCount()
    {
        return _ivenItems.Count;
    }
    
    public void SetCell(ICell cell, int index)
    {
        //Casting to the implemented Cell
        CellItemsData item = cell as CellItemsData;
        item.ConfigureCell(_ivenItems[index], index);
    }
    private void Start()
    {
        List<InventoryItems> lstItem = new List<InventoryItems>();
        for (int i = 0; i < 50; i++)
        {
            InventoryItems invenItem = new InventoryItems();
            invenItem.name = "Item : " + i.ToString();
            invenItem.description = "Description : " + i.ToString();

            lstItem.Add(invenItem);
            
        }
        SetLstItem(lstItem);
        _recyclableScrollRect.ReloadData();
    }
    public void SetLstItem(List<InventoryItems> lstItem)
    {
        _ivenItems = lstItem;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            InventoryItems invenItemDemo = new InventoryItems(name: "ca",description: "fish");
            _ivenItems.Add(invenItemDemo);
            _recyclableScrollRect.ReloadData();
        }
        //Button bật tắt túi đồ
        if (Input.GetKeyDown(KeyCode.B))
        {
            //inventoryGameObject.SetActive(!inventoryGameObject.activeSelf); //activeSelf là trạng thái hiện tại của túi đồ, ! để đảo ngược trạng thái đó
            // _recyclableScrollRect.ReloadData();
            Vector3 currPosInven = inventoryGameObject.GetComponent<RectTransform>().anchoredPosition;
            inventoryGameObject.GetComponent<RectTransform>().anchoredPosition = currPosInven.y == 1000? Vector3.zero : new Vector3(x: 0, y: 1000, z: 0);
        }
    }
    public void AddInventoryItem(InventoryItems item)
    {
        _ivenItems.Add(item);
        _recyclableScrollRect.ReloadData();
    }

}
