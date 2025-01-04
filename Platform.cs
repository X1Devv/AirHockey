using SFML.Graphics;
using SFML.System;

public class Platform
{
    public RectangleShape Shape { get; private set; }
    public float Speed { get; set; }
    public bool NeedToCollide { get; set; }

    public Platform(Vector2f size, Vector2f position, Color color, float speed = 200f)
    {
        Shape = new RectangleShape(size)
        {
            Position = position,
            FillColor = color,
        };
        this.Speed = speed;
        this.NeedToCollide = true;
    }

    public void Update(float deltaTime, Vector2f input, Ball ball)
    {
        Move(0, input.Y * Speed * deltaTime);

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
            ball.Speed = new Vector2f(-ball.Speed.X, ball.Speed.Y);

            if (ballBounds.Top < platformBounds.Top || ballBounds.Top + ballBounds.Height > platformBounds.Top + platformBounds.Height)
                ball.Speed = new Vector2f(ball.Speed.X, -ball.Speed.Y);

            NeedToCollide = false;
        }
        else if (!platformBounds.Intersects(ballBounds))
            NeedToCollide = true;//дуже жорсткий фікс в плані фізики, але воно працює
    }
}
