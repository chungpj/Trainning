// Copyright (c) ChungNA - 2020 All Rights Reserved
using Async.Test;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Test.App.Commands
{
    [Description("Test execute time in Async")]
    internal class ExecuteAsyncTime : IHandleCommand
    {
        public void Handle(string actionName)
        {
            Console.WriteLine(MessageConst.START_COMMAND + actionName);
            var start = DateTime.Now;
            Task firtTask = AsyncMethod(2000);
            Task secondTask = AsyncMethod(3000);
            var continuation = Task.WhenAll(firtTask, secondTask);
            continuation.Wait();
            Console.WriteLine(string.Format("Total execute time = {0} milliseconds", (DateTime.Now - start).TotalMilliseconds));
            Console.WriteLine(MessageConst.END_COMMAND + actionName);
        }

        private Task AsyncMethod(int delayInterval)
        {
            return Task.Run(async () => {
                Console.WriteLine("Method has delay: " + delayInterval + " milliseconds");
                await Task.Delay(delayInterval);
            });
        }
    }
}
