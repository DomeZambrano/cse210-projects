public class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public string GetText()
    {
        return isHidden ? "____" : text;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public bool IsHidden()
    {
        return isHidden;
    }
    public void Unhide()
    {
        isHidden = false;
    }
}
