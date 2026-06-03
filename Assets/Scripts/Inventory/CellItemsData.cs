using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using PolyAndCode.UI;
public class CellItemsData : MonoBehaviour, ICell
{
    //UI
    public Text nameLabel;
    public Text descriptionLabel;
    //Model
    private InventoryItems _contactInfo;
    private int _cellIndex;
    //This is called from the SetCell method in DataSource
    public void ConfigureCell(InventoryItems invenItems, int cellIndex)
    {
        _cellIndex = cellIndex;
        _contactInfo = invenItems;
        nameLabel.text = invenItems.name;
        descriptionLabel.text = invenItems.description;
    }
}
