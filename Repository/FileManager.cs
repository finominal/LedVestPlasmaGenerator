using System.IO;

namespace LedVestPlasmaGenerator.Repository
{
    public class FileManager
    {
        public void WriteBufferToFile(string fileName, byte[] data)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var file = File.Create(fileName))
            {
                file.Write(data, 0, data.Length);
            }
        }
    }
}
