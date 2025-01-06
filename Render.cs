using SFML.Graphics;
using SFML.Window;

public class Render
{
    public RenderWindow Window { get; private set; }
    private List<Drawable> drawables;

    public Render(VideoMode videoMode, string title)
    {
        Window = new RenderWindow(videoMode, title);
        Window.SetFramerateLimit(60);
        drawables = new List<Drawable>();
    }

    public void AddDrawable(params Drawable[] drawablesToAdd)
    {
        foreach (var drawable in drawablesToAdd)
        {
            drawables.Add(drawable);
        }
    }

    public void Clear(Color color) => Window.Clear(color);

    public void Display() => Window.Display();

    public void Draw()
    {
        foreach (var drawable in drawables)
        {
            Window.Draw(drawable);
        }
    }

    public bool IsOpen => Window.IsOpen;
}
