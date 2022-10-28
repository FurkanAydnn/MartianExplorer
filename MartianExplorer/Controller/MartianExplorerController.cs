using MartianExplorer.Helpers;
using MartianExplorer.Models.Entitites;
using MartianExplorer.Services;
using System;
using System.Linq;

namespace MartianExplorer.Controller
{
    public class MartianExplorerController
    {
        private ILocationService _locationService;
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

                if (!martianSurface.Validate())
                {
                    continue;
                }

                var fieldMaxCoordinates = sizeParameters.Split(' ');
                martianSurface.Width = Convert.ToInt32(fieldMaxCoordinates.First());
                martianSurface.Height = Convert.ToInt32(fieldMaxCoordinates.Last());

                _martianSurface = martianSurface;
                _locationService = new LocationService(martianSurface);
                break;
            };
        }

        public void ExploreMars()
        {
            Explorer firstExplorer = null;
            LocationRequest firstLocationRequest = null;
            Explorer secondExplorer = null;
            LocationRequest secondLocationRequest = null;

            while (true)
            {

                try
                {
                    if (firstExplorer == null)
                    {
                        ConsoleHelper.WriteLetterByLetter("Please enter the first explorer's coordinates:");
                        firstExplorer = GetExplorer(Console.ReadLine());
                    }

                    if (firstLocationRequest == null)
                    {
                        ConsoleHelper.WriteLetterByLetter("Please enter the first explorer's move command:");
                        firstLocationRequest = GetMoveCommand(Console.ReadLine());

                    }

                    if (secondExplorer == null)
                    {
                        ConsoleHelper.WriteLetterByLetter("Please enter the second explorer's coordinates:");
                        secondExplorer = GetExplorer(Console.ReadLine());
                    }

                    if (secondLocationRequest == null)
                    {
                        ConsoleHelper.WriteLetterByLetter("Please enter the second explorer's move command");
                        secondLocationRequest = GetMoveCommand(Console.ReadLine());
                    }

                    _locationService.Move(firstExplorer, firstLocationRequest);
                    _locationService.Move(secondExplorer, secondLocationRequest);

                    ConsoleHelper.WriteLetterByLetter($"{firstExplorer.XCoordinate} {firstExplorer.YCoordinate} {firstExplorer.Direction}");
                    ConsoleHelper.WriteLetterByLetter($"{secondExplorer.XCoordinate} {secondExplorer.YCoordinate} {secondExplorer.Direction}");
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

            if (!explorer.Validate())
            {
                throw new ApplicationException("Explorer is not valid");
            }

            string[] explorerParameters = rawData.Split(' ');

            int givenXCoordinate = Convert.ToInt32(explorerParameters[0]);
            int givenYCoordinate = Convert.ToInt32(explorerParameters[1]);

            if(givenXCoordinate < 0)
            {
                explorer.XCoordinate = 0;
            }
            else if(givenXCoordinate > _martianSurface.Width)
            {
                explorer.XCoordinate = _martianSurface.Width;
            }
            else
            {
                explorer.XCoordinate = givenXCoordinate;    
            }
            
            if(givenYCoordinate < 0)
            {
                explorer.YCoordinate = 0;
            }
            else if(givenYCoordinate > _martianSurface.Height)
            {
                explorer.YCoordinate = _martianSurface.Height;
            }
            else
            {
                explorer.YCoordinate = givenYCoordinate;    
            }

            explorer.Direction = Enum.Parse<Direction>(explorerParameters[2].ToUpper());

            return explorer;
        }

        private LocationRequest GetMoveCommand(string rawData)
        {
            var lr = new LocationRequest()
            {
                MoveCommand = rawData
            };

            if (!lr.Validate())
            {
                throw new ApplicationException("Command is not valid");
            }

            return lr;
        }
    }
}
