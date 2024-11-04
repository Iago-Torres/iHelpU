using System;
using System.Collections.Generic;
using iHelpU.MODEL.Models;

namespace iHelpU.MODEL.ViewModel
{
    public class HomePageVM
    {
        public string MensagemBemVindo { get; set; }
        public IEnumerable<AnuncioServico> Anuncios { get; set; }
        public string Primeiro_Nome { get; set; }
        public TimeSpan TempoRestanteSessao { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
    }
}
