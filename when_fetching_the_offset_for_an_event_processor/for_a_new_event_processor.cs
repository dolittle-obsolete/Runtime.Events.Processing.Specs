// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Runtime.Events.Store;
using Machine.Specifications;

namespace Dolittle.Runtime.Events.Processing.InMemory.Specs.when_fetching_the_offset_for_an_event_processor
{
    [Subject(typeof(IEventProcessorOffsetRepository), nameof(IEventProcessorOffsetRepository.Get))]
    public class for_a_new_event_processor : given.an_offset_repository
    {
        static IEventProcessorOffsetRepository repository;
        static CommittedEventVersion result;
        Establish context = () => repository = get_offset_repository();

        Because of = () => _do(repository, (_) => result = _.Get(Guid.NewGuid()));

        It should_return_the_none_commit_version = () => result.ShouldEqual(CommittedEventVersion.None);

        Cleanup cleanup = () => repository.Dispose();
    }
}