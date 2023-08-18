namespace Streams
{
    public static class ReadingFromString
    {
        public static string ReadAllStreamContent(StringReader stringReader)
        {
            string content = stringReader.ReadToEnd();
            return content;
        }

        public static string ReadCurrentLine(StringReader stringReader)
        {
            string? line = stringReader.ReadLine();
#pragma warning disable CS8603
            return line;
#pragma warning restore CS8603
        }

        public static bool ReadNextCharacter(StringReader stringReader, out char currentChar)
        {
            int charValue = stringReader.Read();
            if (charValue != -1)
            {
                currentChar = (char)charValue;
                return true;
            }
            else
            {
                currentChar = ' ';
                return false;
            }
        }

        public static bool PeekNextCharacter(StringReader stringReader, out char currentChar)
        {
            int charValue = stringReader.Peek();
            if (charValue != -1)
            {
                currentChar = (char)charValue;
                return true;
            }
            else
            {
                currentChar = ' ';
                return false;
            }
        }

        public static char[] ReadCharactersToBuffer(StringReader stringReader, int count)
        {
            char[] buffer = new char[count];
            int bytesRead = stringReader.Read(buffer, 0, count);

            if (bytesRead < count)
            {
                Array.Resize(ref buffer, bytesRead);
            }

            return buffer;
        }
    }
}
