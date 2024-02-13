internal class Program
{
    private static void Main(string[] args)
    {
        string log2 = "[INFO]: This is a message for you";
        string log1 = "FIND >>> SOMETHING <===< HERE";
        string log3 = "[ERROR]: Missing ; on line 20";
        string log4 = "[WARNING]: I'm too sexy for my shirt";

        //Console.WriteLine(log2.SubstringAfter(": "));

        Console.WriteLine(log2.SubstringBetween("[", "]"));
        Console.WriteLine(log1.SubstringBetween(">>>", "<===<"));
        //Console.WriteLine(log3.Message());
        //Console.WriteLine(log4.LogLevel());
    
    }
}

public static class LogAnalysis
{
    public static string SubstringBetween(this string logLine, string firstString, string secondString)
    {

        //First Attempt

        /*int firstStringLength = firstString.Length;
        int secondStringLength = secondString.Length;
        int first = logLine.IndexOf(firstString) + firstStringLength;
        int second = logLine.Length - logLine.IndexOf(secondString);
        logLine = logLine.Substring(first,second);*/

        //Second Attempt

        /*int firstStringIndex = logLine.IndexOf(firstString) + 1;
        int secondStringIndex = logLine.IndexOf(secondString) + secondString.Length;
        int length = logLine.Length - secondString.Length;
        logLine = logLine.Substring(firstStringIndex, length);*/

        //Third Attempt
        /*
        //After First String
        int firstLength = firstString.Length;
        int firstIndex = logLine.IndexOf(firstString) + firstLength;
        int length = logLine.Length - firstIndex;
        //string firstSubstring = logLine.Substring(firstIndex, length);

        //Before Second String
        int secondIndex = logLine.IndexOf(secondString) - 1;
        //string secondSubstring = logLine.Substring(0,secondIndex);
        */
         //THANK YOU STACKOVERFLOW
        int pos1 = logLine.IndexOf(firstString) + firstString.Length;
        int pos2 = logLine.IndexOf(secondString);

        logLine = logLine.Substring(pos1, pos2 - pos1);

        return logLine;
    }

    public static string SubstringAfter(this string str, string delimiter)
    {
        int delimLength = delimiter.Length;
        int index = str.IndexOf(delimiter) + delimLength;
        int length = str.Length - index;
        str = str.Substring(index, length);
        return str;
    }

    public static string Message(this string str)
    {
        int colon = str.IndexOf(':');
        str = str.Substring(colon + 1);
        return str.Trim();
    }

    public static string LogLevel(this string str)
    {
        int first = str.IndexOf("[") + 1;
        int second = str.IndexOf("]") - 1;
        str = str.Substring(first, second);
        return str;
    }

}