using System;
using Serilog;

namespace SerilogExample
{
    class Program
    {
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello, world!");

            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");

                Log.Error(ex, "An error occurred while processing: {ErrorMessage}", ex.Message);
            
        }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}

