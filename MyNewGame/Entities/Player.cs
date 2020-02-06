using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;

namespace MyNewGame.Entities
{
    public partial class Player
    {
        private enum Direction { Idle, Up, Down, Left, Right };
        private Direction _primaryDirection;
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
        {


        }

        private void CustomActivity()
        {
            PlayerInput();


        }

        private void PlayerInput()
        {
            var newDirection = Direction.Idle;
            if (InputManager.Xbox360GamePads[0].IsConnected)
            {
                XVelocity = InputManager.Xbox360GamePads[0].LeftStick.Position.X * speed;
                YVelocity = InputManager.Xbox360GamePads[0].LeftStick.Position.Y * speed;

                newDirection = ChangeState(XVelocity, YVelocity);
            }

            if (newDirection != _primaryDirection)
            {
                switch (newDirection)
                {
                    case Direction.Idle:
                        SpriteInstance.CurrentChainName = "Idle";
                        break;
                    case Direction.Up:
                        SpriteInstance.CurrentChainName = "WalkUp";
                        break;
                    case Direction.Down:
                        SpriteInstance.CurrentChainName = "WalkDown";
                        break;
                    case Direction.Left:
                        SpriteInstance.CurrentChainName = "WalkLeft";
                        break;
                    case Direction.Right:
                        SpriteInstance.CurrentChainName = "WalkRight";
                        break;
                }

                _primaryDirection = newDirection;
            }
        }

        private Direction ChangeState(float x, float y)
        {
            var absXVelocity = System.Math.Abs(x);
            var absYVelocity = System.Math.Abs(y);

            //return Direction.Idle;

            if (absXVelocity > absYVelocity)
            {
                if (x > 0)
                {
                    return Direction.Right;
                }
                else if (x < 0)
                {
                    return Direction.Left;
                }
            }
            else if (absYVelocity > absXVelocity)
            {
                if (y > 0)
                {
                    return Direction.Up;
                }
                else if (y < 0)
                {
                    return Direction.Down;
                }
            }
            return Direction.Idle;
        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
    }
}
