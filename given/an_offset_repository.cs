namespace Dolittle.Runtime.Events.Processing.InMemory.Specs.given
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Dolittle.Runtime.Events.Processing;
    public class an_offset_repository
    {
        static Type _sut_provider_type;
        protected static Func<IEventProcessorOffsetRepository> get_offset_repository = () => {
            if(_sut_provider_type == null){
                var asm = Assembly.GetExecutingAssembly();      
                _sut_provider_type = asm.GetExportedTypes().Where(t => t.IsClass && typeof(IProvideTheOffsetRepository).IsAssignableFrom(t)).Single();
            }
            var factory = Activator.CreateInstance(_sut_provider_type) as IProvideTheOffsetRepository;
            return factory.Build();
        };

        public static void _do(IEventProcessorOffsetRepository event_store, Action<IEventProcessorOffsetRepository> @do)
        {
            try
            {
                @do(event_store);
            }
            catch (System.Exception)
            {
                (event_store).Dispose();
                throw;
            }
        }
    }
}