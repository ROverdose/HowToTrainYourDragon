﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MovementTest
{
    class Camera
    {
        public Matrix transform;
        Viewport view;
        public static Vector2 centre;

        public Camera(Viewport newView)
        {
            view = newView;
        }
        public void update(GameTime gametime, Game1 avatar)
        {
            centre = new Vector2(avatar.animatedSprite.Position.X - (view.Width/2), avatar.animatedSprite.Position.Y - (view.Height/2));//
            transform = Matrix.CreateScale(new Vector3(1, 1, 0))*
            Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        }
    }
}
