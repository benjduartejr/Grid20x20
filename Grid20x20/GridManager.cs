namespace Grid20x20
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="GridManager" />
    /// </summary>
    public class GridManager
    {
        /// <summary>
        /// Defines the _grid
        /// </summary>
        private readonly int[][] _grid;

        /// <summary>
        /// Defines the _count
        /// </summary>
        private readonly int _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridManager"/> class.
        /// </summary>
        /// <param name="grid">The grid<see cref="int[][]"/></param>
        /// <param name="count">The count<see cref="int"/></param>
        public GridManager(int[][] grid, int count)
        {
            _grid = grid;
            _count = count;
        }

        /// <summary>
        /// The SolveGrid
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int SolveGrid()
        {
            int[] result = new int[4];
            result[0] = ForHorizontal();
            result[1] = ForVertical();
            result[2] = ForDiagonal1();
            result[3] = ForDiagonal2();
            var final = result.Max();
            return final;
        }

        /// <summary>
        /// The ForHorizontal
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int ForHorizontal()
        {
            int greatestProduct = 0;

            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = 0; j < _grid[i].Length - _count; j++)
                {
                    int tempProduct = 1;
                    for (int z = 0; z < _count; z++)
                    {
                        int xxx = _grid[i][j + z];
                        tempProduct = tempProduct * _grid[i][j + z];
                    }
                    greatestProduct = tempProduct > greatestProduct ? tempProduct : greatestProduct;
                }
            }
            return greatestProduct;
        }

        /// <summary>
        /// The ForVertical
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int ForVertical()
        {
            int greatestProduct = 0;

            for (int i = 0; i < _grid.Length - _count + 1; i++)
            {
                for (int j = 0; j < _grid[i].Length; j++)
                {
                    int tempProduct = 1;
                    for (int z = 0; z < _count; z++)
                    {
                        tempProduct = tempProduct * _grid[i + z][j];
                    }
                    greatestProduct = tempProduct > greatestProduct ? tempProduct : greatestProduct;
                }
            }
            return greatestProduct;
        }

        /// <summary>
        /// The ForDiagonal1
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int ForDiagonal1()
        {
            int greatestProduct = 0;
            int[] best4 = new int[4];

            for (int i = 0; i < _grid.Length - _count + 1; i++)
            {
                Console.WriteLine("--------------{0}------------------", i);
                for (int j = _count - 1; j < _grid[i].Length; j++)
                {                    
                    int tempProduct = 1;
                    for (int z = 0; z < _count; z++)
                    {
                        int xxx = _grid[i + z][j - z];
                        best4[z] = _grid[i + z][j - z];

                        tempProduct = tempProduct * _grid[i + z][j - z];
                    }
                    greatestProduct = tempProduct > greatestProduct ? tempProduct : greatestProduct;
                    Console.WriteLine("Diagonal1: {0}x{1}x{2}x{3}", best4[0], best4[1], best4[2], best4[3]);                    
                }                
            }
            return greatestProduct;
        }

        /// <summary>
        /// The ForDiagonal2
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        private int ForDiagonal2()
        {
            int greatestProduct = 0;
            int[] best4 = new int[4];

            for (int i = 0; i < _grid.Length - _count + 1; i++)
            {
                Console.WriteLine("--------------{0}------------------", i);
                for (int j = 0; j < _grid[i].Length - _count + 1; j++)
                {                    
                    int tempProduct = 1;
                    for (int z = 0; z < _count; z++)
                    {
                        int xxx = _grid[i + z][j + z];
                        best4[z] = _grid[i + z][j + z];
                        
                        tempProduct = tempProduct * _grid[i + z][j + z];
                    }
                    greatestProduct = tempProduct > greatestProduct ? tempProduct : greatestProduct;                    
                    Console.WriteLine("Diagonal2: {0}x{1}x{2}x{3}", best4[0], best4[1], best4[2], best4[3]);                    
                }                
            }
            return greatestProduct;
        }

        /// <summary>
        /// The ToInt
        /// </summary>
        /// <param name="y">The y<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        private static int ToInt(string y)
        {
            int o = int.MinValue;
            int value = int.MinValue;

            if (int.TryParse(y, out o))
            {
                value = o;
            }
            return value;
        }

        /// <summary>
        /// The ReadGridData
        /// </summary>
        /// <param name="path">The path<see cref="string"/></param>
        /// <returns>The <see cref="int[][]"/></returns>
        public static int[][] ReadGridData(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            int[][] dataArray = new int[20][];
            string tempText = File.ReadAllText(path);

            dataArray = tempText.Replace("\r", "").Split('\n').Select(n => n.Split(' ').Select(m => ToInt(m)).ToArray()).ToArray();
            return dataArray;
        }
    }
}
