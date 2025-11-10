using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoMedicamento
{
    public class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }

        public void Adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            var encontrado = listaMedicamentos.FirstOrDefault(m => m.Id == medicamento.Id);
            if (encontrado != null && encontrado.QtdeDisponivel() == 0)
            {
                listaMedicamentos.Remove(encontrado);
                return true;
            }
            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            return listaMedicamentos.FirstOrDefault(m => m.Id == medicamento.Id) ?? new Medicamento();
        }

        public List<Medicamento> Listar()
        {
            return listaMedicamentos;
        }
    }
}
