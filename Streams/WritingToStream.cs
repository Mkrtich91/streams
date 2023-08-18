using System.Globalization;

namespace Streams
{
    public static class WritingToStream
    {
        public static void ReadAndWriteIntegers(StreamReader streamReader, StreamWriter outputWriter)
        {
            string hexString = string.Empty;
            int byteValue;

            while ((byteValue = streamReader.Read()) != -1)
            {
#pragma warning disable S1643
                hexString += byteValue.ToString("X2", CultureInfo.InvariantCulture);
#pragma warning restore S1643
            }

            string digitsString = string.Empty;
            for (int i = 0; i < hexString.Length; i += 2)
            {
                string hexPair = hexString.Substring(i, 2);
                int intValue = Convert.ToInt32(hexPair, 16);
#pragma warning disable S1643
                digitsString += intValue.ToString(CultureInfo.InvariantCulture);
#pragma warning restore S1643
            }

            outputWriter.Write(digitsString);
        }

        public static void ReadAndWriteChars(StreamReader streamReader, StreamWriter outputWriter)
        {
            int character;
            while ((character = streamReader.Read()) != -1)
            {
                char charToWrite = (char)character;
                outputWriter.Write(charToWrite);
            }

            outputWriter.Flush();
        }

        public static void TransformBytesToHex(StreamReader contentReader, StreamWriter outputWriter)
        {
            int byteValue;
            while ((_ = contentReader.Peek()) != -1)
            {
                byteValue = contentReader.Read();

#pragma warning disable CA1305
                string hexString = byteValue.ToString("X2");
#pragma warning restore CA1305
                outputWriter.Write(hexString);
            }

            outputWriter.Flush();
        }

        public static void WriteLinesWithNumbers(StreamReader contentReader, StreamWriter outputWriter)
        {
            int lineNumber = 1;

            while (!contentReader.EndOfStream)
            {
#pragma warning disable CS8600
                string line = contentReader.ReadLine();
#pragma warning restore CS8600

                string formattedLine = $"{lineNumber:D3} {line}";
                outputWriter.WriteLine(formattedLine);

                lineNumber++;
            }

            outputWriter.Flush();
        }

        public static void RemoveWordsFromContentAndWrite(StreamReader contentReader, StreamReader wordsReader, StreamWriter outputWriter)
        {
            var wordsToRemove = new HashSet<string>();
            while (!wordsReader.EndOfStream)
            {
                var word = wordsReader.ReadLine();
#pragma warning disable CS8604
                _ = wordsToRemove.Add(item: word);
#pragma warning restore CS8604
            }

            var content = contentReader.ReadToEnd();
            foreach (var word in wordsToRemove)
            {
#pragma warning disable CA1307
                content = content.Replace(word, string.Empty);
#pragma warning restore CA1307
            }

            outputWriter.Write(content);
        }
    }
}
