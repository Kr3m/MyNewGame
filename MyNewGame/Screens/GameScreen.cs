using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;
using FlatRedBall.Math.Collision;
using MyNewGame.Entities;
using FlatRedBall.TileCollisions;

namespace MyNewGame.Screens
{
    public partial class GameScreen
    {

        void CustomInitialize()
        {
            var relationship = CollisionManager.Self.CreateTileRelationship(PlayerList, SolidCollisions);
            relationship.CollisionOccurred = HandlePlayerCollisionWall;
            relationship.SetMoveCollision(0, 1);
            Camera.Main.X = Camera.Main.OrthogonalWidth / 2.0f;
            Camera.Main.Y = -1 * Camera.Main.OrthogonalHeight / 2.0f;
            FlatRedBall.TileEntities.TileEntityInstantiator.CreateEntitiesFrom(Map);

            var playerVsDoorRelationship = CollisionManager.Self.CreateRelationship(PlayerList, DoorList);
            playerVsDoorRelationship.CollisionOccurred = HandlePlayerVsDoorCollision;

        }

        private void HandlePlayerVsDoorCollision(Player player, Door door)
        {
            MoveToScreen(door.LevelToGoTo);
        }

        private void HandlePlayerCollisionWall(Player player, TileShapeCollection tileShapeCollection)
        {
            FlatRedBall.Debugging.Debugger.Write("Collided with wall...");
        }

        void CustomActivity(bool firstTimeCalled)
        {


        }

        void CustomDestroy()
        {


        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

    }
}
