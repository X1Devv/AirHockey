class Boot
{
    static void Main()
    {
        Render render = WindowInitialize.InitializeRenderWindow();

        Game game = new Game(render);

        game.GameCycle();
    }
}
