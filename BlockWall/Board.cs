﻿using System;
using System.Collections.Generic;
using Eto.Drawing;

namespace BlockWall
{
    public class Board
    {
        private readonly List<Wall> _walls = new List<Wall>();

        /// <summary>
        /// Size in tile units of the rectangular board.
        /// </summary>
        public Size Size { get; private set; }

        /// <summary>
        /// Size in pixels of the rectangular tiles.
        /// </summary>
        public Size TileSize { get; private set; }

        /// <summary>
        /// Thickness in pixels of the grooves between tiles.
        /// </summary>
        public int GrooveThickness { get; private set; }

        /// <summary>
        /// Thickness in pixels of the border around the board.
        /// </summary>
        public int BorderThickness { get; private set; }

        public Board(Size size, Size tileSize, int spacing, int border)
        {
            Size = size;
            TileSize = tileSize;
            GrooveThickness = spacing;
            BorderThickness = border;
        }

        public static Board StandardBoard => new Board(new Size(9, 9), new Size(50, 50), 10, 30);

        public IEnumerable<Wall> Walls => _walls;

        public void InsertWall(Wall wall)
        {
            _walls.Add(wall);
        }

        public bool IsWallBetweenTiles(Point tile1, Point tile2)
        {
            const int wallLength = 2;

            int diffX = tile1.X - tile2.X;
            int diffY = tile1.Y - tile2.Y;

            foreach (var wall in _walls)
            {
                switch (wall.Orientation)
                {
                    case Orientation.Horizontal:
                        if (wall.TilePosition.X >= tile1.X - (wallLength - 1) && wall.TilePosition.X <= tile1.X)
                        {
                            if ((diffY > 0 && wall.TilePosition.Y == tile1.Y) ||
                                (diffY < 0 && wall.TilePosition.Y == tile2.Y))
                            {
                                return true;
                            }
                        }
                        break;
                    case Orientation.Vertical:
                        if (wall.TilePosition.Y >= tile1.Y - (wallLength - 1) && wall.TilePosition.Y <= tile1.Y)
                        {
                            if (diffX > 0 && wall.TilePosition.X == tile1.X ||
                                diffX < 0 && wall.TilePosition.X == tile2.X)
                            {
                                return true;
                            }
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return false;
        }

        public Wall CreateWallToInsertAtPixelLocation(int x, int y)
        {
            var relativePosition = new Point(x - BorderThickness, y - BorderThickness);
            var hunkSize = TileSize + GrooveThickness;

            //check for vertical grooves
            if ((relativePosition.X % hunkSize.Width) - TileSize.Width > 0)
            {
                return new Wall
                {
                    Orientation = Orientation.Vertical,
                    TilePosition = new Point
                    {
                        X = (relativePosition.X / hunkSize.Width) + 1,
                        Y = relativePosition.Y / hunkSize.Height
                    }
                };
            }

            //check for horizontal grooves
            if ((relativePosition.Y % hunkSize.Height) - TileSize.Height > 0)
            {
                return new Wall
                {
                    Orientation = Orientation.Horizontal,
                    TilePosition = new Point
                    {
                        X = relativePosition.X / hunkSize.Width,
                        Y = (relativePosition.Y / hunkSize.Height) + 1
                    }
                };
            }

            return null;
        }

        public Point GetPixelPositionOfWall(Wall wall)
        {
            switch (wall.Orientation)
            {
                case Orientation.Horizontal:
                {
                    return new Point(
                        BorderThickness
                        + wall.TilePosition.X * (TileSize.Width + GrooveThickness),
                        BorderThickness
                        + (wall.TilePosition.Y * TileSize.Height)
                        + (wall.TilePosition.Y -1) * GrooveThickness);
                }
                case Orientation.Vertical:
                    {
                        return new Point(
                            BorderThickness
                            + (wall.TilePosition.X * TileSize.Width)
                            + (wall.TilePosition.X - 1) * GrooveThickness,
                            BorderThickness
                            + wall.TilePosition.Y * (TileSize.Height + GrooveThickness));
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}