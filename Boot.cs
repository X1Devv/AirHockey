class Boot
{
    static void Main(string[] args)
    {
        Render render = new Render();
        Game game = new Game(render);

        game.GameCycle();
    }
}
