namespace BlazorHybridAndroidIntent.Components.Pages;

partial class Home : IDisposable
{
    
    protected override void OnInitialized()
    {
        DataState.FileChanged += DataState_FileChanged;
    }

    private void DataState_FileChanged()
    {
        MainThread.BeginInvokeOnMainThread(StateHasChanged);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        DataState.FileChanged -= DataState_FileChanged;
    }
}
