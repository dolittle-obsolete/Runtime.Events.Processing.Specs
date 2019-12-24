// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.Reflection;

namespace Dolittle.Runtime.Events.Processing.InMemory.Specs.given
{
    public class an_offset_repository
    {
        protected static Func<IEventProcessorOffsetRepository> get_offset_repository = () =>
        {
            if (_sut_provider_type == null)
            {
                var asm = Assembly.GetExecutingAssembly();
                _sut_provider_type = asm.GetExportedTypes().Single(t => t.IsClass && typeof(IProvideTheOffsetRepository).IsAssignableFrom(t));
            }

            var factory = Activator.CreateInstance(_sut_provider_type) as IProvideTheOffsetRepository;
            return factory.Build();
        };

        static Type _sut_provider_type;

        public static void _do(IEventProcessorOffsetRepository event_store, Action<IEventProcessorOffsetRepository> @do)
        {
            try
            {
                @do(event_store);
            }
            catch (Exception)
            {
                event_store.Dispose();
                throw;
            }
        }
    }
}