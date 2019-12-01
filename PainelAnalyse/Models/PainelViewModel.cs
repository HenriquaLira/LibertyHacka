using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PainelAnalyse.Models
{
    public class PainelViewModel
    {
        public List<ScoreTerceiroModel> Score { get; set; }
        public List<CarroModel> Carros { get; set; }
    }
}