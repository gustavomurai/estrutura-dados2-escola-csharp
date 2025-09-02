using System;
using System.Collections.Generic;

namespace EscolaEstruturaDeDados
{
    public class Escola
    {
        public List<Curso> Cursos { get; set; } = new List<Curso>();
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public bool AdicionarCurso(Curso curso)
        {
            if (Cursos.Count >= 5) return false;
            Cursos.Add(curso);
            return true;
        }

        public Curso PesquisarCurso(int id)
        {
            return Cursos.Find(c => c.Id == id);
        }

        public bool RemoverCurso(int id)
        {
            var curso = PesquisarCurso(id);
            if (curso != null && curso.Disciplinas.Count == 0)
            {
                Cursos.Remove(curso);
                return true;
            }
            return false;
        }

        public Aluno PesquisarAlunoPorNome(string nome)
        {
            return Alunos.Find(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
    }
}
