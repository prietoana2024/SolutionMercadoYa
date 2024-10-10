using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMercadoYa.DTO
{
    public class FileRecordDTO
    {
        public int IdFile { get; set; }
        public string? Name { get; set; }

        public string? Path { get; set; }

        public string? ContentType { get; set; }
        public string? FileFormat { get; set; }
    }
}
