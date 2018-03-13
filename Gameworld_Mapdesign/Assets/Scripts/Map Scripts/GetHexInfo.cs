using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetHexInfo : MonoBehaviour
{

    // HexMesh hexMesh;
    // HexCell cell;


    public Text cellInfoDisplay;
    public HexGrid hexGrid;
    public HexMapEditor hexMapEditor;
    public HexCoordinates currentHexCoordinates;

    public HexCell[] preSelectCell;

    public HexCell currentHexCell;
    public string terrain;
    public string elevation;
    public bool IsUnderwater, HasRiver, HasRiverBeginOrEnd, HasRoads, IsSpecial, Walled, IsVisible, IsExplored, Explorable;
    //public Terrain terrain;


    private void Awake()
    {
        hexGrid = hexGrid.GetComponent<HexGrid>();
        hexMapEditor = hexMapEditor.GetComponent<HexMapEditor>();
        preSelectCell = new HexCell[2];
        preSelectCell.SetValue(null, 0);
        preSelectCell.SetValue(null, 1);
    }

    private void Update()
    {
        //hexMapEditor = hexMapEditor.GetComponent<HexMapEditor>();
        if (
        Input.GetMouseButtonUp(0) &&
        !EventSystem.current.IsPointerOverGameObject()
    )
        {
            currentHexCoordinates = hexMapEditor.HandleInput(1);
            Debug.Log(currentHexCoordinates.ToString());
            GetHexGridInfo();
        }
    }

    public void GetHexGridInfo()
    {
        
        currentHexCell = hexGrid.GetCell(currentHexCoordinates);
        terrain = currentHexCell.TerrainTypeIndex.ToString();
        elevation = currentHexCell.Elevation.ToString();
        IsUnderwater = currentHexCell.IsUnderwater;
        HasRiver = currentHexCell.HasRiver;
        HasRiverBeginOrEnd = currentHexCell.HasRiverBeginOrEnd;
        HasRoads = currentHexCell.HasRoads;
        IsSpecial = currentHexCell.IsSpecial;
        Walled = currentHexCell.Walled;
        IsVisible = currentHexCell.IsVisible;
        IsExplored = currentHexCell.IsExplored;
        Explorable = currentHexCell.Explorable;
        currentHexCell.EnableHighlight(Color.yellow);
        if (preSelectCell.GetValue(0) != null && (HexCell)preSelectCell.GetValue(0) != currentHexCell)
        {
            preSelectCell.SetValue(currentHexCell, 1);
            HexCell cell=(HexCell)preSelectCell.GetValue(0);
            cell.DisableHighlight();
            preSelectCell.SetValue(null, 0);
        }else if(preSelectCell.GetValue(1) != null && (HexCell)preSelectCell.GetValue(1) != currentHexCell)
        {
            preSelectCell.SetValue(currentHexCell, 0);
            HexCell cell = (HexCell)preSelectCell.GetValue(1);
            cell.DisableHighlight();
            preSelectCell.SetValue(null, 1);
        }
        else if (preSelectCell.GetValue(0) == null && preSelectCell.GetValue(1)==null) 
        {
            preSelectCell.SetValue(currentHexCell, 0);
        }
        cellInfoDisplay.text = "Terrain：" + terrain + "\n" + "Elevation：" + elevation + "\n" + "Is Underwater：" + IsUnderwater +
            "\n" + "Has River：" + HasRiver + "\n" + "Has River B OR E：" + HasRiverBeginOrEnd + "\n" + "Has Roads：" + HasRoads +
            "\n" + "Is Special：" + IsSpecial + "\n" + "Is Visible：" + IsVisible + "\n" + "Is Explored：" + IsExplored + "\n" + "Explorable：" + Explorable;
    }


}