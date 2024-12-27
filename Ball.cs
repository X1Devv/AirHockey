using SFML.Graphics;
using SFML.System;

public class Ball
{
    public CircleShape Shape { get; private set; }
    public Vector2f Speed { get; set; }
    private RenderWindow window;

    public Ball(RenderWindow window)
    {
        this.window = window;
        Shape = new CircleShape(20)
        {
            FillColor = Color.Black
        };
        ResetPosition();
    }

    public void MoveBall(float deltaTime)
    {
        Shape.Position += Speed * deltaTime;
        CheckBounds();
    }

    private void CheckBounds()
    {
        if (Shape.Position.Y < 0 || Shape.Position.Y + Shape.Radius * 2 > window.Size.Y)
            Speed = new Vector2f(Speed.X, -Speed.Y);
    }

    public void ResetPosition()
    {
        var center = new Vector2f(window.Size.X / 2 - Shape.Radius, window.Size.Y / 2 - Shape.Radius);
        Shape.Position = center;

        Random random = new Random();
        float angle = random.Next(0, 360) * (float)Math.PI / 180;
        Speed = new Vector2f(
            (float)Math.Cos(angle) * 300,
            (float)Math.Sin(angle) * 300
        );
    }
}
