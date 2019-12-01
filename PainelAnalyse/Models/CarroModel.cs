using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PainelAnalyse.Models
{
    public class CarroModel
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string PrecoFipe { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }


        public static List<CarroModel> GetLista()
        {
            List<CarroModel> lista = new List<CarroModel>();
            lista.Add(new CarroModel() { Modelo = "Civic", Marca = "Honda", PrecoFipe = "R$ 56.000", Ano = "2019", Placa = "FIT-9999",Cor ="Prata" });
            return lista;
        }

    }

}