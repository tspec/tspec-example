using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Tspec.Core;

Console.WriteLine($"Running with file {args[0]}");
Console.WriteLine();

using var textReader = File.OpenText(args[0]);

var spec = new Spec();
spec.AddStepDefinition(textReader);
spec.AddStepImplementationAssembly(Assembly.GetExecutingAssembly());
var results = spec.Run().ToList();
foreach (var result in results)
{
    Console.WriteLine(result);
}

Console.WriteLine();
Console.WriteLine("Finished running specs.");