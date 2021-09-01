// Copyright (c) ChungNA - 2020 All Rights Reserved
using Async.Test;
using System;
using System.ComponentModel;

namespace Test.App.Commands
{
    [Description("Test throw exception in Async Void Method")]
    internal class ThrowExceptionInAsyncVoid : IHandleCommand
    {
        public void Handle(string actionName)
        {
            try
            {
                Console.WriteLine(MessageConst.START_COMMAND + actionName);
                throw new NotImplementedException(MessageConst.EXCEPTION_MESSAGE);
            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                Console.WriteLine(MessageConst.END_COMMAND + actionName);
            }
        }
    }
}
