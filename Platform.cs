using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class Platform
{
    public RectangleShape Shape { get; private set; }
    private float speed;

    public Platform(Vector2f size, Vector2f position, Color color, float speed = 200f)
    {
        Shape = new RectangleShape(size)
        {
            Position = position,
            FillColor = color,
        };
        this.speed = speed;
    }

    public void Update(float deltaTime, int PlatformId, Ball ball)
    {
        switch (PlatformId)
        {
            case 1:
                HandleMovement(deltaTime, Keyboard.Key.W, Keyboard.Key.S);
                break;
            case 2:
                HandleMovement(deltaTime, Keyboard.Key.A, Keyboard.Key.D);
                break;
        }

        if (Shape.Position.Y < 0)
            Shape.Position = new Vector2f(Shape.Position.X, 0);

        if (Shape.Position.Y + Shape.Size.Y > 600)
            Shape.Position = new Vector2f(Shape.Position.X, 600 - Shape.Size.Y);

        HandleBallCollision(ball);
    }


    private void HandleMovement(float deltaTime, Keyboard.Key moveUpKey, Keyboard.Key moveDownKey)
    {
        if (Keyboard.IsKeyPressed(moveUpKey))
            Shape.Position = new Vector2f(Shape.Position.X, Shape.Position.Y - speed * deltaTime);
        
        if (Keyboard.IsKeyPressed(moveDownKey))
            Shape.Position = new Vector2f(Shape.Position.X, Shape.Position.Y + speed * deltaTime);
    }

    private void HandleBallCollision(Ball ball)
    {
        if (Shape.GetGlobalBounds().Intersects(ball.Shape.GetGlobalBounds()))
            ball.Speed = new Vector2f(-ball.Speed.X, ball.Speed.Y);
    }


}
