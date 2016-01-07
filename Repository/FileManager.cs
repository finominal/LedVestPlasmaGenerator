using System.IO;

namespace LedVestPlasmaGenerator.Repository
{
    public static class FileManager
    {
        public static void WriteBufferToFile(string fileName, byte[] data, int ledCount)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var header = TransformInteger(ledCount);

            using (var file = File.Create(fileName))
            {
                file.Write(header,0,header.Length);
                file.Write(data, 0, data.Length);
                file.Close();
            }
        }

        private static byte[] TransformInteger(int number)
        {
            byte[] result = new byte[2];
            result[1] = (byte)number;
            result[0] = (byte)(number >> 8);
            return result;
        }
    }
}
