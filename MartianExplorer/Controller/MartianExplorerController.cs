using MartianExplorer.Exceptions;
using MartianExplorer.Helpers;
using MartianExplorer.Models.Entitites;
using MartianExplorer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace MartianExplorer.Controller
{
    public class MartianExplorerController
    {
        private IMoveService _moveService;
        private MartianSurface _martianSurface;

        public void GetInitialParameters()
        {
            ConsoleHelper.WriteLetterByLetter("Welcome to the Martian Explorer...");

            while (true)
            {
                ConsoleHelper.WriteLetterByLetter("Please enter your Mars field size parameters:");

                string sizeParameters = Console.ReadLine();

                MartianSurface martianSurface = new MartianSurface
                {
                    RawData = sizeParameters
                };

                var vr = martianSurface.Validate();

                if (!vr.IsValid)
                {
                    ConsoleHelper.WriteLetterByLetter(vr.Message);
                    continue;
                }

                var fieldMaxCoordinates = sizeParameters.Split(' ');
                martianSurface.Width = Convert.ToInt32(fieldMaxCoordinates.First());
                martianSurface.Height = Convert.ToInt32(fieldMaxCoordinates.Last());

                _martianSurface = martianSurface;
                _moveService = new MoveSerive(martianSurface);
                break;
            };
        }

        public void ExploreMars(int explorerCount)
        {
            (Explorer explorer, MoveCommand moveCommand)[] tuples = new (Explorer, MoveCommand)[explorerCount];

            while (true)
            {
                try
                {
                    for (int i = 0; i < explorerCount; i++)
                    {
                        if (tuples[i].explorer == null)
                        {
                            ConsoleHelper.WriteLetterByLetter($"Please enter the {i + 1}. explorer's coordinates:");
                            tuples[i].explorer = GetExplorer(Console.ReadLine());
                        }

                        if (tuples[i].moveCommand == null)
                        {
                            ConsoleHelper.WriteLetterByLetter($"Please enter the {i + 1}. explorer's move command:");
                            tuples[i].moveCommand = GetMoveCommand(Console.ReadLine());
                        }
                    }

                    tuples.ToList().ForEach(x => _moveService.Move(x.explorer, x.moveCommand));
                    tuples.ToList().ForEach(x => ConsoleHelper.WriteLetterByLetter($"{x.explorer.XCoordinate} {x.explorer.YCoordinate} {x.explorer.Direction.GetDisplay()}"));

                    break;
                }
                catch (Exception ex)
                {
                    ConsoleHelper.WriteLetterByLetter(ex.Message);
                    continue;
                }
            }
        }

        private Explorer GetExplorer(string rawData)
        {
            Explorer explorer = new Explorer()
            {
                RawData = rawData
            };

            var vr = explorer.Validate();

            if (!vr.IsValid)
            {
                throw new ValidationException(vr.Message);
            }

            string[] explorerParameters = rawData.Split(' ');

            int givenXCoordinate = Convert.ToInt32(explorerParameters[0]);
            int givenYCoordinate = Convert.ToInt32(explorerParameters[1]);

            if (givenXCoordinate < 0 || givenXCoordinate > _martianSurface.Width)
            {
                throw new ValidationException($"X coordinate of explorer must be between 0 and {_martianSurface.Width}");
            }

            if (givenYCoordinate < 0 || givenYCoordinate > _martianSurface.Height)
            {
                throw new ValidationException($"Y Coordinate of explorer must be between 0 and {_martianSurface.Width}");
            }

            explorer.XCoordinate = givenXCoordinate;
            explorer.YCoordinate = givenYCoordinate;
            explorerParameters[2].ToUpper().TryGetValueFromDisplay(out Direction direction);
            explorer.Direction = direction;

            return explorer;
        }

        private MoveCommand GetMoveCommand(string rawData)
        {
            var moveCommand = new MoveCommand()
            {
                RawData = rawData
            };

            var vr = moveCommand.Validate();

            if (!vr.IsValid)
            {
                throw new ValidationException(vr.Message);
            }

            moveCommand.Command = rawData.ToUpper();

            return moveCommand;
        }
    }
}