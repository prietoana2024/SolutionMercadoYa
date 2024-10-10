using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SistemaMercadoYa.DTO
{
    public class ImagenDTO
    {
        public int IdImagen { get; set; }

        public string? Nombre { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
