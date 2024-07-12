public class Scripture
{
    private Reference reference;
    private List<Word> words;
    private static Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(wordText => new Word(wordText)).ToList();
    }

    public void HideRandomWords(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var unhiddenWords = words.Where(word => !word.IsHidden()).ToList();
            if (unhiddenWords.Count == 0) break;
            var wordToHide = unhiddenWords[random.Next(unhiddenWords.Count)];
            wordToHide.Hide();
        }
    }

    public bool AreAllWordsHidden()
    {
        return words.All(word => word.IsHidden());
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", words.Select(word => word.GetText()));
        return $"{reference.GetDisplayText()} - {scriptureText}";
    }
    public void Reset()
    {
        foreach (var word in words)
        {
            word.Unhide();
        }
    }
}
