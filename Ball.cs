using SFML.Graphics;
using SFML.System;

public class Ball
{
    public CircleShape Shape { get; private set; }
    public Vector2f Velocity { get; set; }
    private RenderWindow window;
    private float speed;
    private float acceleration;

    public Ball(RenderWindow window, float initialVelocity = 300f)
    {
        this.window = window;
        this.speed = initialVelocity;
        this.acceleration = 10f;

        Shape = new CircleShape(20)
        {
            FillColor = Color.Black
        };
        ResetPosition();
    }

    public void MoveBall(float deltaTime)
    {
        Shape.Position += Velocity * deltaTime;
        speed += acceleration * deltaTime;
        Velocity = VelocityBall(Velocity, speed);
        CheckBounds();
    }

    private void CheckBounds()
    {
        if (Shape.Position.Y < 0 || Shape.Position.Y + Shape.Radius * 2 > window.Size.Y)
        {
            Velocity = new Vector2f(Velocity.X, -Velocity.Y);
            CorrectPositionY();
        }

        if (Shape.Position.X < 0 || Shape.Position.X + Shape.Radius * 2 > window.Size.X)
        {
            Velocity = new Vector2f(-Velocity.X, Velocity.Y);
            CorrectPositionX();
        }
    }

    public void ResetPosition()
    {
        var center = new Vector2f(window.Size.X / 2 - Shape.Radius, window.Size.Y / 2 - Shape.Radius);
        Shape.Position = center;

        Random random = new Random();
        float angle = random.Next(80, 360) * (float)Math.PI / 180;

        Velocity = VelocityBall(new Vector2f((float)Math.Cos(angle), 
            (float)Math.Sin(angle)), speed);
    }

    private Vector2f VelocityBall(Vector2f direction, float currentSpeed)
    {
        float length = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
        if (length > 0)
            return new Vector2f(direction.X / length, direction.Y / length) * currentSpeed;
        return direction;
    }

    private void CorrectPositionX()
    {
        if (Shape.Position.X < 0)
            Shape.Position = new Vector2f(0, Shape.Position.Y);
        else if (Shape.Position.X + Shape.Radius * 2 > window.Size.X)
            Shape.Position = new Vector2f(window.Size.X - Shape.Radius * 2, Shape.Position.Y);
    }

    private void CorrectPositionY()
    {
        if (Shape.Position.Y < 0)
            Shape.Position = new Vector2f(Shape.Position.X, 0);
        else if (Shape.Position.Y + Shape.Radius * 2 > window.Size.Y)
            Shape.Position = new Vector2f(Shape.Position.X, window.Size.Y - Shape.Radius * 2);
    }
}
