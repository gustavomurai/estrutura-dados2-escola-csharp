using System;

namespace EscolaEstruturaDeDados
{
    class Program
    {
        static void Main(string[] args)
        {
            Escola escola = new Escola();
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar curso");
                Console.WriteLine("2 - Pesquisar curso (com disciplinas)");
                Console.WriteLine("3 - Remover curso");
                Console.WriteLine("4 - Adicionar disciplina no curso");
                Console.WriteLine("5 - Pesquisar disciplina (com alunos)");
                Console.WriteLine("6 - Remover disciplina");
                Console.WriteLine("7 - Matricular aluno na disciplina");
                Console.WriteLine("8 - Remover aluno da disciplina");
                Console.WriteLine("9 - Pesquisar aluno (disciplinas)");
                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Id do curso: ");
                        int idCurso = int.Parse(Console.ReadLine());
                        Console.Write("Descrição do curso: ");
                        string descCurso = Console.ReadLine();
                        if (escola.AdicionarCurso(new Curso { Id = idCurso, Descricao = descCurso }))
                            Console.WriteLine("Curso adicionado!");
                        else
                            Console.WriteLine("Não foi possível adicionar (limite atingido).");
                        break;

                    case 2:
                        Console.Write("Id do curso: ");
                        int idC = int.Parse(Console.ReadLine());
                        var curso = escola.PesquisarCurso(idC);
                        if (curso != null)
                        {
                            Console.WriteLine($"Curso: {curso.Descricao}");
                            foreach (var disc in curso.Disciplinas)
                                Console.WriteLine($" - Disciplina: {disc.Descricao}");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 3:
                        Console.Write("Id do curso para remover: ");
                        int idRem = int.Parse(Console.ReadLine());
                        if (escola.RemoverCurso(idRem))
                            Console.WriteLine("Curso removido.");
                        else
                            Console.WriteLine("Não foi possível remover (curso não existe ou tem disciplinas).");
                        break;

                    case 4:
                        Console.Write("Id do curso: ");
                        int idC2 = int.Parse(Console.ReadLine());
                        var curso2 = escola.PesquisarCurso(idC2);
                        if (curso2 != null)
                        {
                            Console.Write("Id da disciplina: ");
                            int idDisc = int.Parse(Console.ReadLine());
                            Console.Write("Descrição da disciplina: ");
                            string descDisc = Console.ReadLine();
                            if (curso2.AdicionarDisciplina(new Disciplina { Id = idDisc, Descricao = descDisc }))
                                Console.WriteLine("Disciplina adicionada!");
                            else
                                Console.WriteLine("Não foi possível adicionar (limite atingido).");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 5:
                        Console.Write("Id do curso: ");
                        int idC3 = int.Parse(Console.ReadLine());
                        var curso3 = escola.PesquisarCurso(idC3);
                        if (curso3 != null)
                        {
                            Console.Write("Id da disciplina: ");
                            int idD3 = int.Parse(Console.ReadLine());
                            var disc3 = curso3.PesquisarDisciplina(idD3);
                            if (disc3 != null)
                            {
                                Console.WriteLine($"Disciplina: {disc3.Descricao}");
                                foreach (var aluno in disc3.Alunos)
                                    Console.WriteLine($" - {aluno.Nome}");
                            }
                            else
                                Console.WriteLine("Disciplina não encontrada.");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 6:
                        Console.Write("Id do curso: ");
                        int idC4 = int.Parse(Console.ReadLine());
                        var curso4 = escola.PesquisarCurso(idC4);
                        if (curso4 != null)
                        {
                            Console.Write("Id da disciplina: ");
                            int idD4 = int.Parse(Console.ReadLine());
                            if (curso4.RemoverDisciplina(idD4))
                                Console.WriteLine("Disciplina removida!");
                            else
                                Console.WriteLine("Não foi possível remover (disciplina inexistente ou com alunos).");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 7:
                        Console.Write("Id do curso: ");
                        int idC5 = int.Parse(Console.ReadLine());
                        var curso5 = escola.PesquisarCurso(idC5);
                        if (curso5 != null)
                        {
                            Console.Write("Id da disciplina: ");
                            int idD5 = int.Parse(Console.ReadLine());
                            var disc5 = curso5.PesquisarDisciplina(idD5);
                            if (disc5 != null)
                            {
                                Console.Write("Id do aluno: ");
                                int idAluno = int.Parse(Console.ReadLine());
                                Console.Write("Nome do aluno: ");
                                string nomeAluno = Console.ReadLine();

                                var aluno = escola.PesquisarAlunoPorNome(nomeAluno);
                                if (aluno == null)
                                {
                                    aluno = new Aluno { Id = idAluno, Nome = nomeAluno };
                                    escola.Alunos.Add(aluno);
                                }

                                if (disc5.MatricularAluno(aluno))
                                    Console.WriteLine("Aluno matriculado!");
                                else
                                    Console.WriteLine("Não foi possível matricular.");
                            }
                            else
                                Console.WriteLine("Disciplina não encontrada.");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 8:
                        Console.Write("Nome do aluno: ");
                        string nomeAluno2 = Console.ReadLine();
                        var aluno2 = escola.PesquisarAlunoPorNome(nomeAluno2);
                        if (aluno2 != null)
                        {
                            Console.Write("Id do curso: ");
                            int idC6 = int.Parse(Console.ReadLine());
                            var curso6 = escola.PesquisarCurso(idC6);
                            if (curso6 != null)
                            {
                                Console.Write("Id da disciplina: ");
                                int idD6 = int.Parse(Console.ReadLine());
                                var disc6 = curso6.PesquisarDisciplina(idD6);
                                if (disc6 != null)
                                {
                                    if (disc6.DesmatricularAluno(aluno2))
                                        Console.WriteLine("Aluno removido da disciplina!");
                                    else
                                        Console.WriteLine("Aluno não estava matriculado.");
                                }
                            }
                        }
                        else
                            Console.WriteLine("Aluno não encontrado.");
                        break;

                    case 9:
                        Console.Write("Nome do aluno: ");
                        string nomeAluno3 = Console.ReadLine();
                        var aluno3 = escola.PesquisarAlunoPorNome(nomeAluno3);
                        if (aluno3 != null)
                        {
                            Console.WriteLine($"Aluno: {aluno3.Nome}");
                            foreach (var d in aluno3.Disciplinas)
                                Console.WriteLine($" - {d.Descricao}");
                        }
                        else
                            Console.WriteLine("Aluno não encontrado.");
                        break;
                }
            }
        }
    }
}
