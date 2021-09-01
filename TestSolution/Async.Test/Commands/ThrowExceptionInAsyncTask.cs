// Copyright (c) ChungNA - 2020 All Rights Reserved
using Async.Test;
using System;
using System.ComponentModel;

namespace Test.App.Commands
{
    [Description("Test throw exception in Async Task Method")]
    internal class ThrowExceptionInAsyncTask : IHandleCommand
    {
        public void Handle(string actionName)
        {
            Console.WriteLine(MessageConst.START_COMMAND + actionName);
            throw new NotImplementedException(MessageConst.EXCEPTION_MESSAGE);
        }
    }
}
