namespace Syntra.PartyApp.Site.Components.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        string OddClass { get => currentCount % 2 == 0 ? "even" : "odd"; }
        private void IncrementCount()
        {
            currentCount++;
        }
       }
}
