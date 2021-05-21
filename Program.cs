using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.CommandLine.Parsing;

namespace system_commandline_decimal_exception
{
    /// <summary>
    /// Successful example
    /// 
    /// $ dotnet run -- --opt-decimal 123.456
    /// ParseResult: [ system-commandline-decimal-exception [ --opt-decimal <123.456> ] ]
    /// --opt-decimal 123.456
    /// 
    /// Exception
    /// 
    /// $ dotnet run -- 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var rootCommand = new RootCommand()
            {
                Description = "Console app to demonstrate System.CommandLine complex type exception"
            };
            rootCommand.Add(new Option<decimal>(new[] { "--opt-decimal" }, description: "A decimal option"));
            rootCommand.Handler = CommandHandler.Create((ParseResult parseResult, IConsole console, ComplexType options) =>
               {
                   console.Out.WriteLine($"{parseResult}");
                   console.Out.WriteLine($"--opt-decimal {options.OptDecimal}");
               });

            rootCommand.InvokeAsync(args);
        }
    }

    public class ComplexType
    {
        public decimal OptDecimal { get; set; }
    }

}
