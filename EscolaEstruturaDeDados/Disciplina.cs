using System;
using System.Collections.Generic;

namespace EscolaEstruturaDeDados
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public bool MatricularAluno(Aluno aluno)
        {
            if (Alunos.Count >= 15) return false; // limite de alunos
            if (!aluno.PodeMatricular()) return false;
            Alunos.Add(aluno);
            aluno.Disciplinas.Add(this);
            return true;
        }

        public bool DesmatricularAluno(Aluno aluno)
        {
            if (Alunos.Contains(aluno))
            {
                Alunos.Remove(aluno);
                aluno.Disciplinas.Remove(this);
                return true;
            }
            return false;
        }
    }
}
