using System;
using System.Collections.Generic;

namespace EscolaEstruturaDeDados
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            if (Disciplinas.Count >= 12) return false;
            Disciplinas.Add(disciplina);
            return true;
        }

        public Disciplina PesquisarDisciplina(int id)
        {
            return Disciplinas.Find(d => d.Id == id);
        }

        public bool RemoverDisciplina(int id)
        {
            var disciplina = PesquisarDisciplina(id);
            if (disciplina != null && disciplina.Alunos.Count == 0)
            {
                Disciplinas.Remove(disciplina);
                return true;
            }
            return false;
        }
    }
}
