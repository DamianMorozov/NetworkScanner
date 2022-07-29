// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Security.Cryptography;

namespace NetworkLib.Assembly;

/// <summary>
/// Embedded assembly.
/// </summary>
public class EmbeddedAssembly
{
    private static Dictionary<string, System.Reflection.Assembly> _dic = null;

    [Obsolete("Obsolete")]
    public static void Load(string embeddedResource, string fileName)
    {
        if (_dic == null)
            _dic = new();

        byte[] ba = null;
        System.Reflection.Assembly asm = null;
        System.Reflection.Assembly curAsm = System.Reflection.Assembly.GetExecutingAssembly();

        using (Stream stm = curAsm.GetManifestResourceStream(embeddedResource))
        {
            // Either the file is not existed or it is not mark as embedded resource
            if (stm == null)
                throw new(embeddedResource + " is not found in Embedded Resources.");

            // Get byte[] from the file from embedded resource
            ba = new byte[(int)stm.Length];
            stm.Read(ba, 0, (int)stm.Length);
            try
            {
                asm = System.Reflection.Assembly.Load(ba);

                // Add the assembly/dll into dictionary
                _dic.Add(asm.FullName, asm);
                return;
            }
            catch
            {
                // Purposely do nothing
                // Unmanaged dll or assembly cannot be loaded directly from byte[]
                // Let the process fall through for next part
            }
        }

        bool fileOk = false;
        string tempFile = "";

        using (SHA1CryptoServiceProvider sha1 = new())
        {
            string fileHash = BitConverter.ToString(sha1.ComputeHash(ba)).Replace("-", string.Empty); ;

            tempFile = Path.GetTempPath() + fileName;

            if (File.Exists(tempFile))
            {
                byte[] bb = File.ReadAllBytes(tempFile);
                string fileHash2 = BitConverter.ToString(sha1.ComputeHash(bb)).Replace("-", string.Empty);

                if (fileHash == fileHash2)
                {
                    fileOk = true;
                }
                else
                {
                    fileOk = false;
                }
            }
            else
            {
                fileOk = false;
            }
        }

        if (!fileOk)
        {
            File.WriteAllBytes(tempFile, ba);
        }

        asm = System.Reflection.Assembly.LoadFile(tempFile);

        _dic.Add(asm.FullName, asm);
    }

    public static System.Reflection.Assembly Get(string assemblyFullName)
    {
        if (_dic == null || _dic.Count == 0)
            return null;

        if (_dic.ContainsKey(assemblyFullName))
            return _dic[assemblyFullName];

        return null;
    }
}
