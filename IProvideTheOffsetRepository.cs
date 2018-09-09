using System;
using System.Linq;
using System.Reflection;
using Machine.Specifications;
using Dolittle.Runtime.Events.Processing;

namespace Dolittle.Runtime.Events.Processing.InMemory.Specs
{
    public interface IProvideTheOffsetRepository
    {
        IEventProcessorOffsetRepository Build();
    }
}