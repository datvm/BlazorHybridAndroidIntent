namespace BlazorHybridAndroidIntent;

public class DataStateService
{
    private string file = "No file";

    public event Action FileChanged = delegate { };

    public string File
    {
        get => file;
        set
        {
            file = value;
            FileChanged();
        }
    }
}
