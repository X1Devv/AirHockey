using SFML.Graphics;
using SFML.System;

public class Zone
{
    public RectangleShape Shape { get; private set; }

    public Zone(Vector2f size, Vector2f position, Color color)
    {
        Shape = new RectangleShape(size)
        {
            FillColor = color,
            Position = position
        };
    }

    public bool CheckBallInZone(Ball ball)
    {
        return Shape.GetGlobalBounds().Intersects(ball.Shape.GetGlobalBounds());
    }
}
