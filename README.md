# Dolittle.Runtime.Events.Processing.Specs

This is a set of acceptance tests that should be implemented for IEventProcessorOffsetRepository implementations.

This is not a .csproj.  Instead it should be included in the implementation as a submodule.

```

git submodule add https://github.com/dolittle/Runtime.Events.Processing.Specs.git Specifications/Processing/Specs

```

and then added as a Compile directive.

So, for example, the Submodule could be in Specifications/Specs and the following added to the
implementation .csproj file:

```
  <ItemGroup>
    <Compile Include="./Specs/**/*.cs" Exclude="./Specs/obj/**/*.cs;./Specs/bin/**/*.cs"/>
  </ItemGroup>

```

The implementation should implement the IProvideOffsetRepository interface which has a single Build() method
that returns the implementation of IEventProcessorOffsetRepository that you wish to test.

```
using Dolittle.Runtime.Events.Processing.Specs;

namespace Dolittle.Runtime.Events.Processing.Specs
{
    public class OffsetRepositoryProvider : IProvideOffsetRepository
    {
        public IEventStore Build() => new Processing.EventProcessorOffsetRepository();
    }
}

```
