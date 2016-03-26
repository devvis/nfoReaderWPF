using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace nfoReader_WPF
{
    class nfoReader
    {
        public nfoReader()
        {
        }

        /// <summary>
        /// Tries to open an nfo-file by using its absolute path
        /// </summary>
        /// <param name="nfoPath">Absolute path to an nfo-file</param>
        /// <returns>A string with all the content from the nfo-file</returns>
        public string readNfoFromPath(string nfoPath)
        {
            string nfoValue = "";
            Encoding enc = Encoding.GetEncoding(865);
            if (File.Exists(nfoPath))
            {
                if (System.IO.Path.GetExtension(nfoPath) == ".nfo")
                {
                    try
                    {
                        using (StreamReader nfo = new StreamReader(nfoPath, enc))
                        {
                            nfoValue = nfo.ReadToEnd();
                            nfo.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Something went wrong..\n" + String.Format(e.Message));
                    }
                    return nfoValue;
                }
                else
                {
                    throw new FileNotFoundException("No valid nfo-file found.");
                }
            }
            else
            {
                throw new FileNotFoundException("Error, file not found (or I'm just lacking permissions to open it).");
            }
        }
    }
}
