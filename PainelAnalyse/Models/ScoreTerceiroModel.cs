using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PainelAnalyse.Models
{
    public class ScoreTerceiroModel
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string NomeMae { get; set; }
        public string Documento { get; set; }
        public string Score { get; set; }

        public static List<ScoreTerceiroModel> GetLista()
        {
            List<ScoreTerceiroModel> lista = new List<ScoreTerceiroModel>();
            lista.Add(new ScoreTerceiroModel() { Nome = "Pedro Paulo Soraes", Endereco = "Avenida Belmira Marim , 134", NomeMae = "Ana Soares", Documento = "392.765.478-78", Score = "C" });
            return lista;
        }
    }

}