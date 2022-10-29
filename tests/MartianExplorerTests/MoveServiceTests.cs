using MartianExplorer.Models.Entitites;
using MartianExplorer.Services;
using NUnit.Framework;

namespace MartianExplorerTests
{
    public class MoveServiceTests
    {
        private IMoveService _moveService;
        private MartianSurface _surface;

        [OneTimeSetUp]
        public void Setup()
        {
            _surface = new MartianSurface()
            {
                Height = 5,
                Width = 5
            };

            _moveService = new MoveService(_surface);
        }

        [Test]
        [TestCaseSource(nameof(Cases))]
        public void HandleMove_ValidArgs_MoveExplorer((Explorer explorerBeforeMove, MoveCommand moveCommand, Explorer explorerAfterMove) given)
        {
            //Given & When
            _moveService.Move(given.explorerBeforeMove, given.moveCommand);

            //Then
            Assert.Multiple(() =>
            {
                Assert.That(given.explorerBeforeMove.XCoordinate, Is.EqualTo(given.explorerAfterMove.XCoordinate));
                Assert.That(given.explorerBeforeMove.YCoordinate, Is.EqualTo(given.explorerAfterMove.YCoordinate));
                Assert.That(given.explorerBeforeMove.Direction, Is.EqualTo(given.explorerAfterMove.Direction));
            });

        }

        static (Explorer explorerBeforeMove, MoveCommand moveCommand, Explorer explorerAfterMove)[] Cases =
        {
            (
                new Explorer()
                {
                    XCoordinate= 1,
                    YCoordinate = 2,
                    Direction = Direction.North
                },
                new MoveCommand()
                {
                    Command="LMLMLMLMM"
                },
                new Explorer()
                {
                    XCoordinate= 1,
                    YCoordinate = 3,
                    Direction = Direction.North
                }
            ),
            (
                new Explorer()
                {
                    XCoordinate= 3,
                    YCoordinate = 3,
                    Direction = Direction.East
                },
                new MoveCommand()
                {
                    Command="MMRMMRMRRM"
                },
                new Explorer()
                {
                    XCoordinate= 5,
                    YCoordinate = 1,
                    Direction = Direction.East
                }
            )
        };
    }
}