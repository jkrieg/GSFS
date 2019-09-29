using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeOne
{
    public class ResisterBand
    {
        public int? SignificantDigit { get; private set; }
        public double? Multiplier { get; private set; }
        public double? TolerancePercent { get; private set; }
        public ResisterBand(int? significantDigit, double? multiplier, double? tolerancePercent)
        {
            SignificantDigit = significantDigit;
            TolerancePercent = tolerancePercent;
            Multiplier = multiplier;
        }
        public static ResisterBand Parse(string bandName)
        {
            if (string.IsNullOrWhiteSpace(bandName)) return null;
            string name = bandName.ToLower();
            switch (name)
            {
                case "none":
                case "m":  return None;
                case "pink":
                case "pk": return Pink;
                case "silver":
                case "k":
                case "sr": return Silver;
                case "gold":
                case "gd":
                case "j": return Gold;
                case "black":
                case "bk": return Black;
                case "brown":
                case "bn":
                case "f":  return Brown;
                case "red":
                case "rd":
                case "g": return Red;
                case "orange":
                case "og":
                case "w": return Orange;
                case "yellow":
                case "ye":
                case "p": return Yellow;
                case "green":
                case "gn":
                case "d": return Green;
                case "blue":
                case "bu":
                case "c": return Blue;
                case "violet":
                case "vt":
                case "b": return Violet;
                case "grey":
                case "gray":
                case "gy":
                case "l":
                case "a": return Grey;
                case "white":
                case "wh": return White;
                default: return null;
            }
        }
        public static readonly ResisterBand None = new ResisterBand(null, null, 20);
        public static readonly ResisterBand Pink = new ResisterBand(null, 0.001, null);
        public static readonly ResisterBand Silver = new ResisterBand(null, 0.01, 5);
        public static readonly ResisterBand Gold = new ResisterBand(null, 0.1, 0);
        public static readonly ResisterBand Black = new ResisterBand(0, 1, 1);
        public static readonly ResisterBand Brown = new ResisterBand(1, 10, 1);
        public static readonly ResisterBand Red = new ResisterBand(2, 100, 2);
        public static readonly ResisterBand Orange = new ResisterBand(3, 1000, 0.05);
        public static readonly ResisterBand Yellow = new ResisterBand(4, 10000, 0.02);
        public static readonly ResisterBand Green = new ResisterBand(5, 100000, 0.5);
        public static readonly ResisterBand Blue = new ResisterBand(6, 1000000, 0.25);
        public static readonly ResisterBand Violet = new ResisterBand(7, 10000000, 0.1);
        public static readonly ResisterBand Grey = new ResisterBand(8, 100000000, 0.01);
        public static readonly ResisterBand White = new ResisterBand(9, 1000000000, 0.0);
    }
}
