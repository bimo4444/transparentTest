using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transparentTest
{
    class ArrowButtonsFactory
    {
        int x = 17; // axis
        int[] locations = { 0, 12, 31, 43 }; // points
        public ArrowButton[] Make()
        {
            return new ArrowButton[]
            {
                new ArrowButton(Directions.Left)
                {
                    Top = x,
                    Left = locations[0]
                },
                new ArrowButton(Directions.Right, true)
                {
                    Top = x,
                    Left = locations[1]
                },
                new ArrowButton(Directions.Left, true)
                {
                    Top = x,
                    Left = locations[2]
                },
                new ArrowButton(Directions.Right)
                {
                    Top = x,
                    Left = locations[3]
                },
                new ArrowButton(Directions.Up)
                {
                    Top = locations[0],
                    Left = x
                },
                new ArrowButton(Directions.Down, true)
                {
                    Top = locations[1],
                    Left = x
                },
                new ArrowButton(Directions.Up, true)
                {
                    Top = locations[2],
                    Left = x
                },
                new ArrowButton(Directions.Down)
                {
                    Top = locations[3],
                    Left = x
                }
            };
        }
    }
}
