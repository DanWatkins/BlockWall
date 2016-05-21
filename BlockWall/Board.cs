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
                if (wall.Orientation == Orientation.Horizontal)
                {
                    if (diffY > 0 && wall.Position.Y == tile1.Y)
                        return true;
                    else if (diffY < 0 && wall.Position.Y == tile2.Y)
                        return true;
                }
                else if (wall.Orientation == Orientation.Vertical)
                {
                    if (diffX > 0 && wall.Position.X == tile1.X)
                        return true;
                    else if (diffX < 0 && wall.Position.X == tile2.X)
                        return true;
                }
            }

            return false;
        }
    }
}