using Ninject;
using SimplifiedSlotMachine.Common;
using SimplifiedSlotMachine.Common.Services;
using SimplifiedSlotMachine.Services.Contracts;
using System;
using System.Reflection;

namespace SimplifiedSlotMachine.Services
{
    public class Engine : IEngine
    {
        private readonly IRequestTranslator parser;
        private readonly IFactory factory;
        private readonly IRNDCalculator calculator;
        private readonly IGenerator generator;
        private readonly IPlayGame play;
        private readonly IWriter writer;

        static Engine()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            Instance = new Engine(kernel);
        }

        private Engine(StandardKernel kernel)
        {
            this.parser = kernel.Get<IRequestTranslator>();
            this.factory = kernel.Get<IFactory>();
            this.calculator = kernel.Get<IRNDCalculator>();
            this.generator = kernel.Get<IGenerator>();
            this.play = kernel.Get<IPlayGame>();
            this.writer = kernel.Get<IWriter>();
        }

        public void Run()
        {
            while (true)
            {
                // Read -> Process -> Print -> Repeat
                writer.WriteLine(GlobalMessages.WelcomeMsg);
                string input = this.Read();
                string result = this.Process(input);
                this.Print(result);
            }
        }

        public static IEngine Instance { get; }

        private string Read()
        {
            return Console.ReadLine();
        }

        private string Process(string commandLine)
        {
            if (commandLine.ToLower() == GlobalMessages.EndCmd.ToLower())
            {
                Environment.Exit(0);
            }

            try
            {
                var game = this.factory.Create(this.parser.Parse(commandLine));
                var result = this.play.Play(game, this.calculator, this.generator, this.writer);

                if (result == null)
                {
                    return GlobalMessages.GameOver;
                }

                return result;
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                return $"ERROR: {e.Message}";
            }
        }

        private void Print(string msg)
        {
            writer.WriteLine(msg);
        }
    }
}