// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Dolittle.Runtime.Events.Store;
using Machine.Specifications;

namespace Dolittle.Runtime.Events.Processing.InMemory.Specs.when_setting_the_offset_for_an_event_processor
{
    [Subject(typeof(IEventProcessorOffsetRepository), nameof(IEventProcessorOffsetRepository.Set))]
    public class and_has_a_previous_offset : given.an_offset_repository
    {
        static IEventProcessorOffsetRepository repository;
        static CommittedEventVersion current_version;
        static CommittedEventVersion last_processed;
        static EventProcessorId event_processor;

        Establish context = () =>
        {
            current_version = new CommittedEventVersion(99, 1, 1);
            last_processed = new CommittedEventVersion(100, 1, 1);
            event_processor = Guid.NewGuid();
            repository = get_offset_repository();
            _do(repository, _ => _.Set(event_processor, current_version));
        };

        Because of = () => _do(repository, _ => _.Set(event_processor, last_processed));

        It should_update_the_last_processed_version_for_the_processor = () => _do(repository, _ => _.Get(event_processor).ShouldEqual(last_processed));
        Cleanup cleanup = () => repository.Dispose();
    }
}