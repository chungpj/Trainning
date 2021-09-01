// Copyright (c) ChungNA - 2020 All Rights Reserved
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Test.App.Commands;
using Test.App.Models;

namespace Async.Test
{
    class Program
    {
        private static readonly IList<IHandleCommand> CommandHandlers = new List<IHandleCommand>();
        private static readonly List<CommandModel> OptionTests = new List<CommandModel>();
        static void Main()
        {
            Console.WriteLine("--- LEARN ABOUT ---");
            try
            {
                PrintHelper();
                DoCommand();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception message: " + ex.Message);
                PrintHelper();
            }

            Console.ReadKey();
        }

        private static List<CommandModel> InitCommandOptions()
        {
            OptionTests.Add(new CommandModel { Id = 1, Name = nameof(ExecuteAsyncTime), Description = GetDescription(typeof(ExecuteAsyncTime)) });
            OptionTests.Add(new CommandModel { Id = 2, Name = nameof(ThrowExceptionInAsyncTask), Description = GetDescription(typeof(ThrowExceptionInAsyncTask)) });
            OptionTests.Add(new CommandModel { Id = 3, Name = nameof(ThrowExceptionInAsyncVoid), Description = GetDescription(typeof(ThrowExceptionInAsyncVoid)) });
            return OptionTests;
        }

        private static string GetDescription(Type type)
        {
            var descriptions = (DescriptionAttribute[])
                type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptions.Length == 0)
            {
                return null;
            }
            return descriptions[0].Description;
        }

        private static void InitCommands()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (typeof(IHandleCommand).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    CommandHandlers.Add((IHandleCommand)Activator.CreateInstance(type));
                }
            }
        }

        private static void PrintHelper()
        {
            if (OptionTests.Count == 0)
                InitCommandOptions();
            Console.WriteLine("\nTest option: ");
            foreach (var option in OptionTests)
            {
                Console.WriteLine(string.Format("\t{0}. {1}", option.Id, option.Name));
            }
            Console.WriteLine("(Please input Id to run test..)");
            DoCommand();
        }

        private static void DoCommand()
        {
            if (CommandHandlers.Count == 0)
                InitCommands();

            var userInput = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(userInput))
            {
                PrintHelper();
                return;
            }

            var userOption = OptionTests.FirstOrDefault(c => c.Id.ToString() == userInput);
            if (userOption == null)
            {
                PrintHelper();
                return;
            }

            var command = CommandHandlers.First(c => c.ToString().Contains(userOption.Name));
            command.Handle(userOption.Description);
            PrintHelper();
        }
    }
}
