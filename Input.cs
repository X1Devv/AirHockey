using SFML.System;
using SFML.Window;

public class Input
{
    public Vector2f GetPlatformInput(int platformId)
    {
        float y = 0;

        if (platformId == 1)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                y -= 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                y += 1;
        }
        else if (platformId == 2)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                y -= 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                y += 1;
        }

        return new Vector2f(0, y);
    }
}