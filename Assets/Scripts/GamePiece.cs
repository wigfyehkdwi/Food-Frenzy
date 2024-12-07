﻿using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public int score;

    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set
        {
            if(IsMovable())
            {
                x = value;
            }
        }
    }

    public int Y
    {
        get { return y; }
        set
        {
            if (IsMovable())
            {
                y = value;
            }
        }
    }

    private GameGrid.PieceType type;

    public GameGrid.PieceType Type
    {
        get { return type; }
    }

    private GameGrid grid;

    public GameGrid GridRef
    {
        get { return grid; }
    }

    private MovablePiece movableComponent;

    public MovablePiece MovableComponent
    {
        get { return movableComponent; }
    }

    private ColorPiece colorComponent;

    public ColorPiece ColorComponent
    {
        get { return colorComponent; }
    }

    private ClearablePiece clearableComponent;

    public ClearablePiece ClearableComponent
    {
        get { return clearableComponent; }
    }

    private void Awake()
    {
        movableComponent = GetComponent<MovablePiece>();
        colorComponent = GetComponent<ColorPiece>();
        clearableComponent = GetComponent<ClearablePiece>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int _x, int _y, GameGrid _grid, GameGrid.PieceType _type)
    {
        x = _x;
        y = _y;
        grid = _grid;
        type = _type;
    }

    private void OnMouseDown()
    {
        grid.PressPiece(this);
    }

    private void OnMouseEnter()
    {
        grid.EnterPiece(this);
    }

    private void OnMouseUp()
    {
        grid.ReleasePiece();
    }

    public bool IsMovable()
    {
        return movableComponent != null;
    }

    public bool IsColored()
    {
        return colorComponent != null;
    }

    public bool IsClearable()
    {
        return clearableComponent != null;
    }
}
