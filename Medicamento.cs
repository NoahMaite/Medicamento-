using System;
using System.Collections.Generic;

namespace ProjetoMedicamento
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio { get; set; }
        public Queue<Lote> Lotes { get; set; }

        public Medicamento()
        {
            Lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio) : this()
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
        }

        public int QtdeDisponivel()
        {
            int total = 0;
            foreach (var lote in Lotes)
                total += lote.Qtde;
            return total;
        }

        public void Comprar(Lote lote)
        {
            Lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            int restante = qtde;

            while (restante > 0 && Lotes.Count > 0)
            {
                var lote = Lotes.Peek();

                if (lote.Qtde <= restante)
                {
                    restante -= lote.Qtde;
                    Lotes.Dequeue();
                }
                else
                {
                    lote.Qtde -= restante;
                    restante = 0;
                }
            }

            return restante == 0;
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Laboratorio} - {QtdeDisponivel()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Medicamento m)
                return m.Id == Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
