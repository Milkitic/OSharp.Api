using System;

namespace OsuSharp.V1
{
    [Flags]
    public enum Mod
    {
        None =        0x00000000,
        NoFail =      0x00000001,
        Easy =        0x00000002,
        TouchDevice = 0x00000004,
        Hidden =      0x00000008,
        HardRock =    0x00000010,
        SuddenDeath = 0x00000020,
        DoubleTime =  0x00000040,
        Relax =       0x00000080,
        HalfTime =    0x00000100,
        NightCore =   0x00000200, // Only set along with DoubleTime. i.e: NC only gives 576
        Flashlight =  0x00000400,
        Autoplay =    0x00000800,
        SpunOut =     0x00001000,
        Relax2 =      0x00002000, // Autopilot
        Perfect =     0x00004000, // Only set along with SuddenDeath. i.e: PF only gives 16416  
        Key4 =        0x00008000,
        Key5 =        0x00010000,
        Key6 =        0x00020000,
        Key7 =        0x00040000,
        Key8 =        0x00080000,
        FadeIn =      0x00100000,
        Random =      0x00200000,
        Cinema =      0x00400000,
        Target =      0x00800000,
        Key9 =        0x01000000,
        KeyCoop =     0x02000000,
        Key1 =        0x04000000,
        Key3 =        0x08000000,
        Key2 =        0x10000000,
        ScoreV2 =     0x20000000,
        LastMod =     0x40000000,
        KeyMod = Key1 | Key2 | Key3 | Key4 | Key5 | Key6 | Key7 | Key8 | Key9 | KeyCoop,
        FreeModAllowed = NoFail | Easy | Hidden | HardRock | SuddenDeath | Flashlight | FadeIn | Relax | Relax2 | SpunOut | KeyMod,
        ScoreIncreaseMods = Hidden | HardRock | DoubleTime | Flashlight | FadeIn
    }
}
