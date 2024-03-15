using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace Projeto1TDVD
{
    internal class Player
    {
        // Point = Vector2 ,diferença é na precisão, point é int e Vector2 é float

        private Point position;
        public Point Position => position;

        public Player(int x, int y)
        {
            position = new Point(x, y);
        }



    }
}
