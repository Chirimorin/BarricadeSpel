﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeSpel.Model
{
    public class Movable
    {
        protected Field _position;
        public virtual Field Position 
        { 
            get { return _position; }
            set 
            {
                if (value != null)
                {
                    if (_position != null)
                    {
                        _position.Contains = null;
                        _position.RemoveMovable(this);
                    }
                    _position = value;
                    _position.Contains = this;
                }
            } 
        }

        public int DrawIndex { get; set; } //Useful for keeping track of which drawing belongs to which position. Views are expected to add drawings to a list starting at index 0 in order of drawing.

        public string Type { get; set; }

        //Functions
        /*public void MoveTo(Field field) //TODO return hit pawn, let player move barricade
        {
            Barricade barricade = null;
            Pawn pawn = null;
            if (field.Contains != null)
            {
                if (field.Contains.Type == "barricade")
                    barricade = (Barricade)field.Contains;
                if (field.Contains.Type == "pawn")
                    pawn = (Pawn)field.Contains;
            }
            Position = field; //setter updates field containers
            if (pawn != null)
            {
                //Return pawn to forest or start
            }
            if (barricade != null)
            {
                //Let player move the barricade
            }
        }*/
    }
}
