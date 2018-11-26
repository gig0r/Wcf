using MyDataEntityLibrary.Data;
using MyDataEntityLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataEntityLibrary
{
    public class FileManager
    {
        private FileDbContext _context;

        public FileManager(FileDbContext context)
        {
            _context = context;
        }

        public Stream Download(int id)
        {
            if (id > 0)
            {
                using (var data = new MemoryStream(_context.Files.FirstOrDefault(f => f.Id == id).Data))
                {
                    return data;
                }
            }
            return null;
        }

        public string Upload(string name, string desc, Stream data)
        {
            _context.Files.Add(new FileModel
            {
                Name = name,
                Description = desc,
                Data = Conv.ToByteArray(data)
            });
            _context.SaveChanges();
            return "e";
        }

        public bool Delete(int id)
        {
            var file = _context.Files.FirstOrDefault(f => f.Id == id);
            if (file != null)
            {
                _context.Files.Remove(file);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }

    public static class Conv
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
        }

    }
}
