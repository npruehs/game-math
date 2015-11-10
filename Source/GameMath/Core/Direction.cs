namespace GameMath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///   Cardinal direction.
    /// </summary>
    [CLSCompliant(true)]
    [Flags]
    public enum Direction
    {
        /// <summary>
        ///   No direction.
        /// </summary>
        None = 0,

        /// <summary>
        ///   North.
        /// </summary>
        North = 1 << 0,

        /// <summary>
        ///   East.
        /// </summary>
        East = 1 << 1,

        /// <summary>
        ///   South.
        /// </summary>
        South = 1 << 2,

        /// <summary>
        ///   West.
        /// </summary>
        West = 1 << 3,

        /// <summary>
        ///   North, east, south and west.
        /// </summary>
        All = North | East | South | West,

        /// <summary>
        ///   Northeast.
        /// </summary>
        NorthEast = North | East,

        /// <summary>
        ///   Southeast.
        /// </summary>
        SouthEast = South | East,

        /// <summary>
        ///   Southwest.
        /// </summary>
        SouthWest = South | West,

        /// <summary>
        ///   Northwest.
        /// </summary>
        NorthWest = North | West,

        /// <summary>
        ///   West and east.
        /// </summary>
        Horizontal = West | East,

        /// <summary>
        ///   North and south.
        /// </summary>
        Vertical = North | South
    }

    /// <summary>
    ///   Utility methods for cardinal directions.
    /// </summary>
    [CLSCompliant(true)]
    public static class Directions
    {
        #region Public Methods and Operators

        /// <summary>
        ///   All eight cardinal directions, starting north, in clockwise order.
        /// </summary>
        /// <returns>All cardinal directions.</returns>
        public static IEnumerable<Direction> All()
        {
            yield return Direction.North;
            yield return Direction.NorthEast;
            yield return Direction.East;
            yield return Direction.SouthEast;
            yield return Direction.South;
            yield return Direction.SouthWest;
            yield return Direction.West;
            yield return Direction.NorthWest;
        }

        /// <summary>
        ///   All diagonal directions, starting north-west, in clockwise order.
        /// </summary>
        /// <returns>All diagonal directions.</returns>
        public static IEnumerable<Direction> Diagonal()
        {
            yield return Direction.NorthWest;
            yield return Direction.NorthEast;
            yield return Direction.SouthEast;
            yield return Direction.SouthWest;
        }

        /// <summary>
        ///   Four horizonal and vertical directions, starting north, in clockwise order.
        /// </summary>
        /// <returns>Four horizonal and vertical directions.</returns>
        public static IEnumerable<Direction> HorizontalVertical()
        {
            yield return Direction.North;
            yield return Direction.East;
            yield return Direction.South;
            yield return Direction.West;
        }

        /// <summary>
        ///   Checks whether the specified direction is diagonal.
        /// </summary>
        /// <param name="direction">Direction to check.</param>
        /// <returns>
        ///   <c>true</c>, if the direction is diagonal, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool IsDiagonal(this Direction direction)
        {
            return Diagonal().Contains(direction);
        }

        /// <summary>
        ///   Checks whether the specified direction is horizontal.
        /// </summary>
        /// <param name="direction">Direction to check.</param>
        /// <returns>
        ///   <c>true</c>, if the direction is horizontal, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool IsHorizontal(this Direction direction)
        {
            return (direction & Direction.Horizontal) != 0;
        }

        /// <summary>
        ///   Checks whether the specified direction is vertical.
        /// </summary>
        /// <param name="direction">Direction to check.</param>
        /// <returns>
        ///   <c>true</c>, if the direction is vertical, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool IsVertical(this Direction direction)
        {
            return (direction & Direction.Vertical) != 0;
        }

        /// <summary>
        ///   Returns the opposite of the passed direction.
        /// </summary>
        /// <param name="direction">Direction to get the opposite of.</param>
        /// <returns>Opposite of the passed direction.</returns>
        public static Direction Opposite(this Direction direction)
        {
            var opposite = direction;

            // Flip vertically.
            if ((direction & Direction.North) != 0)
            {
                opposite = (opposite & ~Direction.North) | Direction.South;
            }
            else if ((direction & Direction.South) != 0)
            {
                opposite = (opposite & ~Direction.South) | Direction.North;
            }

            // Flip horizontally.
            if ((direction & Direction.West) != 0)
            {
                opposite = (opposite & ~Direction.West) | Direction.East;
            }
            else if ((direction & Direction.East) != 0)
            {
                opposite = (opposite & ~Direction.East) | Direction.West;
            }

            return opposite;
        }

        #endregion
    }
}