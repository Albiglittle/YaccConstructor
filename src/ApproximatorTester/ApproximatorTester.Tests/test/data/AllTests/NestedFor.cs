﻿{caret}namespace N
{
    class Program
    {
        static void Main(string[] args)
        {
            string query = "select";
            for (int i = 0; i < 10; i++)
            {
                string iStr = "i";
                for (int j = 0; j < 10; j++)
                {
                    query += iStr;   
                }
            }
            Program.ExecuteImmediate(query);
        }

        static void ExecuteImmediate(string query)
        {
            
        }
    }
}
