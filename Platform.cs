using SFML.Graphics;
using SFML.System;

public class Platform
{
    public RectangleShape Shape { get; private set; }
    public float Velocity { get; set; }
    public bool NeedToCollide { get; set; }

    public Platform(Vector2f size, Vector2f position, Color color, float velocity = 200f)
    {
        Shape = new RectangleShape(size)
        {
            Position = position,
            FillColor = color,
        };
        this.Velocity = velocity;
        this.NeedToCollide = true;
    }

    public void Update(float deltaTime, Vector2f input, Ball ball)
    {
        Move(0, input.Y * Velocity * deltaTime);

        if (Shape.Position.Y < 0)
            Shape.Position = new Vector2f(Shape.Position.X, 0);

        if (Shape.Position.Y + Shape.Size.Y > 600)
            Shape.Position = new Vector2f(Shape.Position.X, 600 - Shape.Size.Y);

        HandleBallCollision(ball);
    }

    public void Move(float x, float y)
    {
        Shape.Position += new Vector2f(x, y);
    }

    private void HandleBallCollision(Ball ball)
    {
        FloatRect platformBounds = Shape.GetGlobalBounds();
        FloatRect ballBounds = ball.Shape.GetGlobalBounds();

        if (platformBounds.Intersects(ballBounds) && NeedToCollide)
        {
            ball.Velocity = new Vector2f(-ball.Velocity.X, ball.Velocity.Y);

            if (ballBounds.Top < platformBounds.Top || ballBounds.Top + ballBounds.Height > platformBounds.Top + platformBounds.Height)
                ball.Velocity = new Vector2f(ball.Velocity.X, -ball.Velocity.Y);

            NeedToCollide = false;
        }
        else if (!platformBounds.Intersects(ballBounds))
            NeedToCollide = true;
    }
}
