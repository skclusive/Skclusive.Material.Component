using Skclusive.Core.Component;

namespace Skclusive.Material.Progress
{
    public class ProgressStyleProvider : StyleTypeProvider
    {
        public ProgressStyleProvider() : base(priority: 160, typeof(CircularProgressStyle), typeof(LinearProgressStyle))
        {
        }
    }
}