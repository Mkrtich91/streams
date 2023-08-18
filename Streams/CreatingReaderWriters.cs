using System.Globalization;
using System.Text;

[assembly: CLSCompliant(true)]

namespace Streams
{
    public static class CreatingReaderWriters
    {
        public static StringReader CreateStringReader(string str)
        {
            StringReader stringReader = new StringReader(str);
            return stringReader;
        }

        public static StringWriter CreateStringWriter()
        {
            StringWriter stringWriter = new StringWriter();
            return stringWriter;
        }

        public static StringWriter CreateStringWriterThatWritesToStringBuilder(StringBuilder stringBuilder)
        {
            StringWriter stringWriter = new StringWriter(stringBuilder);
            return stringWriter;
        }

        public static StringWriter CreateStringWriterThatWritesCultureSpecificData(CultureInfo cultureInfo)
        {
            StringWriter stringWriter = new StringWriter(cultureInfo);
            return stringWriter;
        }

        public static StreamReader CreateStreamReaderFromStream(Stream stream)
        {
            StreamReader streamReader = new StreamReader(stream);
            return streamReader;
        }

        public static StreamWriter CreateStreamWriterToStream(Stream stream)
        {
            StreamWriter streamWriter = new StreamWriter(stream);
            return streamWriter;
        }
    }
}
