﻿// Copyright 2007-2014 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Transports.RabbitMq.Tests
{
    using System;
    using System.Threading.Tasks;
    using MassTransit.Pipeline;


    class TestReceivePipe :
        IReceivePipe
    {
        readonly Func<ReceiveContext, Task> _callback;

        public TestReceivePipe(Func<ReceiveContext, Task> callback)
        {
            _callback = callback;
        }

        public async Task Send(ReceiveContext context)
        {
            await Task.Yield();

            await _callback(context);
        }

        public bool Inspect(IPipeInspector inspector)
        {
            return true;
        }
    }

    class TestConsumePipe :
        IConsumePipe
    {
        readonly Func<ConsumeContext, Task> _callback;

        public TestConsumePipe(Func<ConsumeContext, Task> callback)
        {
            _callback = callback;
        }

        public async Task Send(ConsumeContext context)
        {
            await Task.Yield();

            await _callback(context);
        }

        public bool Inspect(IPipeInspector inspector)
        {
            return true;
        }
    }
}