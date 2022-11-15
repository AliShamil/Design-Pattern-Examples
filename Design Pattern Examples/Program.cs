namespace Design_Pattern_Examples;

interface IButton
{
    public void Render();
    public void OnClick();
}


class Windows_Button : IButton
{
    public void OnClick() => Console.WriteLine("Clicked By Windows Button");

    public void Render() => Console.WriteLine("Rendered By Windows Button");
}

class HTML_Button : IButton
{
    public void OnClick() => Console.WriteLine("Clicked By HTML Button");

    public void Render() => Console.WriteLine("Rendered By HTML Button");
}


abstract class Dialog
{
    public void Render()
    {
        IButton okButton = CreateButton();
        okButton.OnClick();
        okButton.Render();
    }

    public abstract IButton CreateButton();
}


class WindowsDialog : Dialog
{
    public override IButton CreateButton()
        => new Windows_Button();
}

class WebDialog : Dialog
{
    public override IButton CreateButton()
        => new HTML_Button();
}


class Program
{
    static void Main()
    {
        Dialog dialog = null;
        while (true)
        {
            Console.Clear();
            Console.WriteLine(@"
                        1: Windows
                        2: Web
                        Any: Exit");



            Console.Write("\n\tEnter choice: ");


            dialog = Console.ReadLine() switch
            {
                "1" => new WindowsDialog(),
                "2" => new WebDialog(),
                _ => null
            };



            if (dialog == null)
                break;

            Console.WriteLine();
            dialog.Render();
            Console.ReadKey();
        }

    }
}