using SFML.Window;

public static class WindowInitialize
{
    public static Render InitializeRenderWindow()
    {
        VideoMode videoMode = new VideoMode(1200, 600);
        Render render = new Render(videoMode, "Air hockey");
        return render;
    }
}
