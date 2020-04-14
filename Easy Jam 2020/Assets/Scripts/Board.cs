using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class Board : MonoBehaviour
{
    [SerializeField] Tile TilePrefab = null;

    private Tile[,] _grid;

    private const int ColCount = 12;
    private const int RowCount = 18;

    public bool IsReady { get; private set; } = false;

    public bool IsFilled
    {
        get
        {
            ElementType elementType = GetTile(0, 0).ElementType;

            foreach (var tile in _grid)
            {
                if (tile.ElementType != elementType)
                    return false;
            }

            return true;
        }
    }

    private void Start()
    {
        StartCoroutine(CreateGrid());
    }

    private IEnumerator CreateGrid()
    {
        _grid = new Tile[ColCount, RowCount];

        for (int row = 0; row < RowCount; row++)
        {
            for (int col = 0; col < ColCount; col++)
            {
                CreateTile(col, row);
                yield return new WaitForSeconds(0.01f);
            }
        }

        IsReady = true;

        yield return null;
    }

    private void CreateTile(int col, int row)
    {
        Tile tile = Instantiate(TilePrefab, new Vector3(col, -row), Quaternion.identity, transform);
        tile.SetElement(Elements.GetRandomElement());
        tile.name = $"Tile ({col}, {row})";

        _grid[col, row] = tile;
    }

    public Tile GetTile(int col, int row)
    {
        if (col >= 0 && col < ColCount && row >= 0 && row < RowCount)
            return _grid[col, row];
        else
            return null;
    }

    public void Fill(ElementDef elementDef)
    {
        foreach (Tile tile in GetTilesToChange())
        {
            tile.SetElement(elementDef);
        }
    }

    private IEnumerable<Tile> GetTilesToChange()
    {
        ElementType elementType = GetTile(0, 0).ElementType;

        HashSet<Tile> list = new HashSet<Tile>();

        AddTile(0, 0);

        void AddTile(int col, int row)
        {
            Tile tile = GetTile(col, row);

            if (tile?.ElementType == elementType)
            {
                if (!list.Contains(tile))
                {
                    list.Add(tile);

                    AddTile(col + 1, row);
                    AddTile(col, row + 1);
                    AddTile(col - 1, row);
                    AddTile(col, row - 1);
                }
            }
        }

        return list;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3((ColCount / 2f) - 0.5f, (-RowCount / 2f) + 0.5f), new Vector3(ColCount, RowCount));
    }
}
