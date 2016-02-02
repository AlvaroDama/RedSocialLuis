using System;

namespace ContactosModel.Model
{
    public class MensajeModel
    {
        public int Id { get; set; }
        public int IdDestino { get; set; }
        public int IdOrigen { get; set; }
        public string Asunto { get; set; }
        public DateTime Fecha { get; set; }
        public bool Leido { get; set; }
        public string Estado => Leido ? "Leído" : "Sin leer";
        public string Contenido { get; set; }
    }
}