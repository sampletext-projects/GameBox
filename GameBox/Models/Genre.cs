using System;

namespace GameBox.Models
{
    [Flags]
    public enum Genre
    {
        Unknown = 0,
        RTS = 1,
        FPS = 2,
        ThreeD = 4,
        CityBuilding = 8,
        Arcade = 16,
        Adventure = 32
    }
}