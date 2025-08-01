using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        if (!_mazeMap[(_currX, _currY)][0])
            throw new InvalidOperationException("Can't go that way!");
        _currX -= 1;
    }

    public void MoveRight()
    {
        if (!_mazeMap[(_currX, _currY)][1])
            throw new InvalidOperationException("Can't go that way!");
        _currX += 1;
    }

    public void MoveUp()
    {
        if (!_mazeMap[(_currX, _currY)][2])
            throw new InvalidOperationException("Can't go that way!");
        _currY -= 1;
    }

    public void MoveDown()
    {
        if (!_mazeMap[(_currX, _currY)][3])
            throw new InvalidOperationException("Can't go that way!");
        _currY += 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
