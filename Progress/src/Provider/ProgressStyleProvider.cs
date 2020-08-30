using Skclusive.Core.Component;

namespace Skclusive.Material.Progress
{
    public class ProgressStyleProvider : StyleTypeProvider
    {
        public ProgressStyleProvider() : base(typeof(CircularProgressStyle), typeof(LinearProgressStyle))
        {
        }
    }
}