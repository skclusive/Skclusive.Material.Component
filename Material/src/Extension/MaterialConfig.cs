using Skclusive.Core.Component;

namespace Skclusive.Material.Component
{
    public interface IMaterialConfig : ICoreConfig
    {
    }

    public abstract class MaterialConfigBuilder<B, C> : CoreConfigBuilder<B, C>
    where B : MaterialConfigBuilder<B, C>
    where C : IMaterialConfig
    {
        protected class MaterialConfig : CoreConfig, IMaterialConfig
        {
        }

        protected MaterialConfigBuilder(MaterialConfig config) : base(config)
        {
        }
    }

    public class MaterialConfigBuilder : MaterialConfigBuilder<MaterialConfigBuilder, IMaterialConfig>
    {
        public MaterialConfigBuilder() : base(new MaterialConfig())
        {
        }

        protected override IMaterialConfig Config()
        {
            return (IMaterialConfig)_config;
        }

        protected override MaterialConfigBuilder Builder()
        {
            return this;
        }
    }
}