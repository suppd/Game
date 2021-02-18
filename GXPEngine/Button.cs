using System;
using GXPEngine;
using System.Drawing;

public class Button : Sprite
{
    public Button() : base("button.png", false)
    {

    }
}

public class ButtonRetry : Sprite
{
    public ButtonRetry() : base("Button-Retry.png")
    {
        SetOrigin(width / 2, height / 2);
    }
}


public class ButtonHow : Sprite
{
    public ButtonHow() : base("button.png")
    {
        SetOrigin(width / 2, height / 2);
    }
}

public class ButtonQuit : Sprite
{
    public ButtonQuit() : base("button.png")
    {
        SetOrigin(width / 2, height / 2);
    }
}

public class ButtonVolume : Sprite
{
    public ButtonVolume() : base("volume.png")
    {
        SetOrigin(width / 2, height / 2);
    }
}


public class ButtonVolumeNot : Sprite
{
    public ButtonVolumeNot() : base("volumenot.png")
    {
        SetOrigin(width / 2, height / 2);
    }
}