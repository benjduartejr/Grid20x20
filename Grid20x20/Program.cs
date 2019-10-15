namespace Grid20x20
{
    using System;

    /// <summary>
    /// Defines the <see cref="Program" />
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/></param>
        internal static void Main(string[] args)
        {
            SolveGrid();
        }

        /// <summary>
        /// The SolveGrid
        /// </summary>
        private static void SolveGrid()
        {
            var gridData = GridManager.ReadGridData("inputData.txt");
            GridManager sg = new GridManager(gridData, 4);
            Console.WriteLine("Biggest Product in the Grid: {0:n0}", sg.SolveGrid());
        }
    }
}
