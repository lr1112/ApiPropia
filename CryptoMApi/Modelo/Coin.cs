using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMApi.Modelo
{
    public class Coin
    {
        [Key]
        public int MonedaId { get; set; }
        public string? Descripcion { get; set; }
        public double? Valor { get; set; }
        public string? ImageUrl { get; set; }
    }
}
