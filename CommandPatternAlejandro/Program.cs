using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Castle.Components.DictionaryAdapter.Xml;
using Ninject;
using Ninject.Parameters;

namespace CommandPatternAlejandro
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = RegisterNinject.RegisterClasses();





            var command = new CreateProductCommand() {Name = "El Producto"};
            var gate = container.Get<IGate>();

            gate.Dispatch(command);

            var updateCommand = new UpdateProductCommand() {Name = "El Nuevo Producto", ProductId = 1};
            gate.Dispatch(updateCommand);

            Console.ReadLine();
        }
    }
}