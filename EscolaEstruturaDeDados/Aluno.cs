using System;
using System.Collections.Generic;

namespace EscolaEstruturaDeDados
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Cada aluno pode se matricular em no máximo 6 disciplinas
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public bool PodeMatricular()
        {
            return Disciplinas.Count < 6;
        }
    }
}
