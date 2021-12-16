using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private Vector3 originPos;

    public Grid(int height, int width, float cellSize, Vector3 originPos)
    {
        this.height = height;
        this.width = width;
        this.cellSize = cellSize;
        this.originPos = originPos;

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                UtilsClass.CreateWorldText(
                    gridArray[x, y].ToString(),
                    null,
                    GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f,
                    10,
                    Color.white,
                    TextAnchor.MiddleCenter
                );
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(
            GetWorldPosition(0, height),
            GetWorldPosition(width, height),
            Color.white,
            100f);
        Debug.DrawLine(
            GetWorldPosition(width, 0),
            GetWorldPosition(width, height),
            Color.white,
            100f);
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPos;
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
            gridArray[x, y] = value;
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
            return gridArray[x, y];
        else
            return 0;
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPos).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPos).y / cellSize);
    }
}
