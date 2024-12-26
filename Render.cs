using SFML.Graphics;
using SFML.Window;
public class Render
{
    public RenderWindow Window { get; set; }
    private List<Drawable> drawables;

    public Render()
    {
        Window = new RenderWindow(new VideoMode(1200, 600), "Air hockey");
        Window.Closed += (sender, e) => Window.Close();
        drawables = new List<Drawable>();
    }

    public void AddDrawable(Drawable drawable)
    {
        drawables.Add(drawable);
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

    public void DispatchEvents() => Window.DispatchEvents();

    public bool IsOpen => Window.IsOpen;
}
