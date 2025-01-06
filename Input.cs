using SFML.System;
using SFML.Window;

public class Input
{
    public Vector2f GetPlatformInput(int platformId)
    {
        float y = 0;

        if (platformId == 1)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Up))
                y -= 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.Down))
                y += 1;
        }
        else if (platformId == 2)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
                y -= 1;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Left))
                y += 1;
        }

        return new Vector2f(0, y);
    }
}