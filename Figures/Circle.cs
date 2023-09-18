﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Circle : IFigure
    {
        private double _radius;

        public bool CheckIfValid()
        {
            return _radius > 0;
        }

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double CalculateArea()
        {
            if (CheckIfValid())
            {
                return Math.PI* _radius *_radius;
            }
            return -1;
        }
    }
}
