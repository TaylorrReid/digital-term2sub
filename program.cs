using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace name
{
    class Program {
        public static void Main()
	{
		int M = 10, N = 10;
        //Making the grid
		int[,] grid = new int[M,N];

		Random morf = new Random();

		for (int i = 0; i < M; i++)
		{
			for (int j = 0; j < N; j++)
			{
				grid[i, j] = morf.Next(3);
			}
			Console.WriteLine();
		}



		// Displaying the grid      
		Console.WriteLine("Original Generation" );
		for (int i = 0; i < M; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (grid[i,j] == 0)
					Console.Write("*");
				else if(grid[i,j] == 1)
					Console.Write("#");
				else
					Console.Write("&");
			}
			Console.WriteLine();
		}
		Console.WriteLine();
		nextGeneration(grid, M, N);
	}

public static class Logger
{
    public static StringBuilder LogString = new StringBuilder();
    public static void WriteLine(string str)
    {
        Console.WriteLine(str);
        LogString.Append(str).Append(Environment.NewLine);
    }
    public static void Write(string str)
    {
        Console.Write(str);
        LogString.Append(str);

    }
    public static void SaveLog(bool Append = false, string Path = "./Log.txt")
    {
        if (LogString != null && LogString.Length > 0)
        {
            if (Append)
            {
                using (StreamWriter file = System.IO.File.AppendText(Path))
                {
                    file.Write(LogString.ToString());
                    file.Close();
                    file.Dispose();
                }
            }
            else
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Path))
                {
                    file.Write(LogString.ToString());
                    file.Close();
                    file.Dispose();
                }
            }               
        }
    }
}



	// Function to print next generation
	static void nextGeneration(int [,]grid,
							int M, int N)
	{
		int[,] future = new int[M,N];

		// Loop through every cell
		for (int l = 1; l < M - 1; l++)
		{
			for (int m = 1; m < N - 1; m++)
			{
				
				// finding number Of Neighbours that are alive
				int aliveNeighbours = 0;
				for (int i = -1; i <= 1; i++)
					for (int j = -1; j <= 1; j++)
						aliveNeighbours +=
								grid[l + i,m + j];

				// The cell needs to be subtracted from its neighbours as it was counted before
				aliveNeighbours -= grid[l,m];

				// Implementing the Rules of Life

				// Cell is lonely and dies
				if ((grid[l,m] == 1) &&
							(aliveNeighbours < 2))
					future[l,m] = 0;

				// Cell dies due to over population
				else if ((grid[l,m] == 1) &&
							(aliveNeighbours > 3))
					future[l,m] = 0;

				// A new cell is born
				else if ((grid[l,m] == 0) &&
							(aliveNeighbours == 3))
					future[l,m] = 1;

				// Remains the same
				else
					future[l,m] = grid[l,m];
			}
		}

		Console.WriteLine("Next Generation");
		for (int i = 0; i < M; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (future[i,j] == 0)
					Console.Write("*");
				else if(grid[i,j] == 1)
					Console.Write("#");
				else 
					Console.Write("&");
			}
			Console.WriteLine();
		}
	}
    }
					
public class MaleFemale
{
	public class Cell {
		public int ctype = 0;

		public int getType() {
             return this.ctype;
        }
		
		public int setType(int new_type) {
             this.ctype = new_type;
			 return this.ctype;
        }
		
		public bool isAlive() {
            if(this.ctype >= 1) return true;
			return false;
        }
		
		public bool isMale() {
             return this.ctype == 1;
        }
		
		public bool isFemale() {
            return this.ctype == 2;
        }
		
		public Cell() {
			this.ctype = 0;
        }
    }
	}
}
