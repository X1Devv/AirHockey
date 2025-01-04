using SFML.System;
using SFML.Graphics;

public class Game
{
    private Render render;
    private Clock clock;

    private Platform RadiantPlatform;
    private Platform DirePlatform;

    private Ball ball;

    private Zone RadiantZone;
    private Zone DireZone;

    private Input input;

    private int RadiantScore = 0;
    private int DireScore = 0;

    public Game(Render render)
    {
        this.render = render;
        clock = new Clock();
        input = new Input();
    }

    public void GameCycle()
    {
        CreateObjects();

        while (render.IsOpen)
        {
            float deltaTime = clock.Restart().AsSeconds();
            (Vector2f radiantInput, Vector2f direInput) = GetInput();

            render.Clear(Color.White);
            render.DispatchEvents();

            BallMove(deltaTime);
            PlatformUpdate(deltaTime, radiantInput, direInput);

            CheckZones();

            render.Draw();
            render.Display();
        }
    }

    public void BallMove(float deltaTime)
    {
        ball.MoveBall(deltaTime);
    }
    public void ResetBall()
    {
        ball.ResetPosition();
    }
    public (Vector2f, Vector2f) GetInput()
    {
        Vector2f radiantInput = input.GetPlatformInput(1);
        Vector2f direInput = input.GetPlatformInput(2);
        return (radiantInput, direInput);
    }

    public void PlatformUpdate(float deltaTime, Vector2f radiantInput, Vector2f direInput)
    {
        RadiantPlatform.Update(deltaTime, radiantInput, ball);
        DirePlatform.Update(deltaTime, direInput, ball);
    }


    public void CheckZones()
    {
        if (RadiantZone.CheckBallInZone(ball))
        {
            DireScore++;
            ResetBall();
            Console.WriteLine($"Score> Radiant {RadiantScore} - {DireScore} Dire");
        }

        if (DireZone.CheckBallInZone(ball))
        {
            RadiantScore++;
            ResetBall();
            Console.WriteLine($"Score> Radiant {RadiantScore} - {DireScore} Dire");
        }
    }

    public void CreateObjects()
    {
        RadiantZone = new Zone(new Vector2f(100, 1000), new Vector2f(0, 0), Color.Blue);
        DireZone = new Zone(new Vector2f(100, 1000), new Vector2f(1100, 0), Color.Red);

        RadiantPlatform = new Platform(new Vector2f(30, 150), new Vector2f(200, 300), Color.Black);
        DirePlatform = new Platform(new Vector2f(30, 150), new Vector2f(970, 300), Color.Black);


        ball = new Ball(render.Window);

        render.AddDrawable(RadiantZone.Shape, DireZone.Shape, ball.Shape,
            RadiantPlatform.Shape, DirePlatform.Shape);
    }
}