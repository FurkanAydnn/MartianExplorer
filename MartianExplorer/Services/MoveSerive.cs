using MartianExplorer.Helpers;
using MartianExplorer.Models.Entitites;
using System;

namespace MartianExplorer.Services
{
    public interface IMoveService
    {
        void Move(Explorer explorer, MoveCommand moveCommand);
    }
    public class MoveSerive : IMoveService
    {
        private readonly MartianSurface _martianSurface;

        public MoveSerive(MartianSurface marsField)
        {
            _martianSurface = marsField;
        }


        void IMoveService.Move(Explorer explorer, MoveCommand moveCommand)
        {
            foreach (var cmd in moveCommand.Command)
            {
                int newDirectoinAsInt;
                switch (cmd)
                {
                    case 'R':
                        newDirectoinAsInt = ((int)explorer.Direction + 1) % 4;
                        explorer.Direction = (Direction)newDirectoinAsInt;
                        break;
                    case 'L':
                        newDirectoinAsInt = (int)explorer.Direction - 1;
                        explorer.Direction = (Direction)(newDirectoinAsInt < 0 ? 3 : newDirectoinAsInt);
                        break;
                    case 'M':
                        StepForward(explorer);
                        break;
                    default:
                        break;
                }
            }
        }

        private void StepForward(Explorer explorer)
        {
            switch (explorer.Direction)
            {
                case Direction.North:
                    explorer.YCoordinate = Math.Min(explorer.YCoordinate + 1, _martianSurface.Height);
                    break;
                case Direction.East:
                    explorer.XCoordinate = Math.Min(explorer.XCoordinate + 1, _martianSurface.Width);
                    break;
                case Direction.South:
                    explorer.YCoordinate = Math.Max(explorer.YCoordinate - 1, 0);
                    break;
                case Direction.West:
                    explorer.XCoordinate = Math.Max(explorer.XCoordinate - 1, 0);
                    break;
            }
        }
    }
}