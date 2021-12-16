using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    [SerializeField] GameObject mapAreaCanvas;
    [SerializeField] float mapAreaHeight;
    [SerializeField] float mapAreaWidth;

    // Start is called before the first frame update
    void Start()
    {
        mapAreaCanvas = GameObject.Find("Map_Area");

        mapAreaHeight = mapAreaCanvas.GetComponent<RectTransform>().rect.height;
        mapAreaWidth = mapAreaCanvas.GetComponent<RectTransform>().rect.width;

        Debug.Log(mapAreaHeight + " " + mapAreaWidth);

        // Grid grid = new Grid(4, 2, 10f);
        Grid grid = new Grid(
            (int)Math.Round(mapAreaHeight),
            (int)Math.Round(mapAreaWidth),
            .9f,
            new Vector3(-258, -192)
        );
    }
}
