using System;
using System.Collections.Generic;

namespace BlockWall
{
    public class Board
    {
        private List<Wall> _walls = new List<Wall>();

        public void PlaceWall(Wall wall)
        {
            _walls.Add(wall);
        }

        public bool IsWallBetweenTiles(Point tile1, Point tile2)
        {
            int diffX = tile1.X - tile2.X;
            int diffY = tile1.Y - tile2.Y;

            foreach (var wall in _walls)
            {
                if (diffX != 0 && wall.Orientation == Orientation.Vertical)
                {
                    if (wall.Position.X == tile2.X)
                        return true;
                }
                else if (diffY != 0 && wall.Orientation == Orientation.Horizontal)
                {
                    if (wall.Position.Y == tile1.Y)
                        return true;
                }
            }

            return false;
        }
    }
}