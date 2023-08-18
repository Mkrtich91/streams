using System.Text;

namespace Streams
{
    public static class ReadingFromStream
    {
        public static string ReadAllStreamContent(StreamReader streamReader)
        {
            return streamReader.ReadToEnd();
        }

        public static string[] ReadLineByLine(StreamReader streamReader)
        {
            List<string> lines = new List<string>();
            string line;
#pragma warning disable CS8600
            while ((line = streamReader.ReadLine()) != null)
            {
                lines.Add(line);
            }
#pragma warning restore CS8600
            return lines.ToArray();
        }

        public static StringBuilder ReadOnlyLettersAndNumbers(StreamReader streamReader)
        {
            StringBuilder result = new StringBuilder();

            while (streamReader.Peek() != -1)
            {
                char nextChar = (char)streamReader.Peek();

                if (char.IsLetterOrDigit(nextChar))
                {
                    _ = result.Append(nextChar);
                    _ = streamReader.Read();
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public static char[][] ReadAsCharArrays(StreamReader streamReader, int arraySize)
        {
#pragma warning disable IDE0059
#pragma warning disable S1854
            char[][] charArrays = Array.Empty<char[]>();
#pragma warning restore S1854
#pragma warning restore IDE0059
            string content = streamReader.ReadToEnd();

            int totalArrays = (int)Math.Ceiling((double)content.Length / arraySize);
            charArrays = new char[totalArrays][];

            for (int i = 0; i < totalArrays; i++)
            {
                int startIndex = i * arraySize;
                int endIndex = Math.Min(startIndex + arraySize, content.Length);
                int arrayLength = endIndex - startIndex;

                charArrays[i] = new char[arrayLength];
                content.CopyTo(startIndex, charArrays[i], 0, arrayLength);
            }

            return charArrays;
        }
    }
}
