using SFML.Graphics;
using SFML.System;

public class Game
{
    private Render render;

    public Game(Render render)
    {
        this.render = render;
    }

    public void GameCycle()
    {
        CreateObjects();

        while (render.IsOpen)
        {
            render.DispatchEvents();

            render.Clear(Color.White);
            render.Draw();
            render.Display();
        }
    }

    public void BallMove()
    {

    }

    public void CanBallMove()
    {

    }

    private (int, int) CalcCenter()
    {
        return ((int)render.Window.Size.X / 2, (int)render.Window.Size.Y / 2);
    }

    public void CreateObjects()
    {
        var DireZone = new RectangleShape(new Vector2f(100, 1000))
        {
            FillColor = Color.Red,
            Position = new Vector2f(1100, 0)
        };

        var RadiantZone = new RectangleShape(new Vector2f(100, 1000))
        {
            FillColor = Color.Blue,
            Position = new Vector2f(0, 0)
        };

        var Ball = new CircleShape(50)
        {
            FillColor = Color.Black,
        };

        (int x, int y) = CalcCenter();
        Ball.Position = new Vector2f(x - Ball.Radius, y - Ball.Radius);
        
        render.AddDrawable(DireZone);
        render.AddDrawable(RadiantZone);
        render.AddDrawable(Ball);
    }
}