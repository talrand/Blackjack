﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public static class CardFactory
    {
        public static Card Create(int cardNumber)
        {
            switch (cardNumber)
            {
                case 11:
                    return new Card("Jack", 10);
                case 12:
                    return new Card("Queen", 10);
                case 13:
                    return new Card("King", 10);
                default:
                    return new Card(cardNumber.ToString(), cardNumber);
            }
        }
    }
}